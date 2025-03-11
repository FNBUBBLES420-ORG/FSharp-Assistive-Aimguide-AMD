// LICENSE
// This project is proprietary and all rights are reserved by the author.
// Unauthorized copying, distribution, or modification of this project is strictly prohibited.
// Unless You have written permission from the Developer or the FNBUBBLES420 ORG.

module AssistiveAimGuide

open System
open System.Diagnostics
open System.Threading
open System.Threading.Tasks
open RJCP.IO.Ports
open InputSimulatorStandard
open ScreenCapture

// Define the captureScreenAsync function
let captureScreenAsync () : Task<byte[]> =
    Task.Run(fun () ->
        // Simulate screen capture logic
        let screenData = Array.zeroCreate<byte> 1024 // Example byte array
        screenData
    )
open YOLOInference

// Define the runInferenceAsync function
let runInferenceAsync (imageData: byte[]) : Async<float[]> =
    async {
        // Simulate inference logic
        let detected = [| 0.5; 0.5 |] // Example detection result
        return detected
    }
open InputControl

// Define the gameSelection function
let gameSelection () =
    let knownGames = ["GameA"; "GameB"; "GameC"] // List of known game process names
    let runningGames =
        Process.GetProcesses()
        |> Array.filter (fun p -> knownGames |> List.contains p.ProcessName)
        |> Array.map (fun p -> p.ProcessName)
    
    if runningGames.Length > 0 then
        printfn "Please select a game:"
        runningGames |> Array.iteri (fun i game -> printfn "%d. %s" (i + 1) game)
        match Console.ReadKey(true).Key with
        | key when key >= ConsoleKey.D1 && key <= ConsoleKey.D9 ->
            let index = int key - int ConsoleKey.D1
            if index < runningGames.Length then
                Some runningGames.[index]
            else
                None
        | _ -> None
    else
        printfn "No known games are currently running."
        None

// Initialize global variables
let simulator = new InputSimulator()
let rand = Random()
let mutable frameCount = 0
let mutable lastTime = Stopwatch.StartNew()
let cts = new CancellationTokenSource() // For stopping async loops

// 🆘 Display Help Message
let showHelpMessage () =
    printfn "📧 Need help? Join FNBubbles420 Org Community Discord Server"
    printfn "🔗 Invite Link: https://discord.fnbubbles420.org/invite"
    printfn "📌 Go To Assistive AimGuide Channel and ping @Bubbles The Dev"
    printfn "=========================================================="

// ✅ Optional Serial Communication Setup for Arduino Leonardo
let mutable port: SerialPortStream option = None

try
    let serialPort = new SerialPortStream("COM3", 115200)
    serialPort.Open()
    if serialPort.IsOpen then
        printfn "✅✅ Connected to Arduino Leonardo on COM3! 🔌🤖"
        port <- Some serialPort
    else
        printfn "⚠️ Arduino Leonardo is not connected. Running without serial integration."
with ex ->
    printfn "⚠️ No Arduino Leonardo detected. Running without serial support."
    port <- None

// Ensure proper disposal on process exit
AppDomain.CurrentDomain.ProcessExit.Add(fun _ ->
    match port with
    | Some p when p.IsOpen -> 
        printfn "🔌🚪 Closing serial port... See you later, Arduino! 👋"
        p.Dispose()
    | _ -> ()
)

// ✅ Only read from Arduino if it's connected
if port.IsSome then
    if port.Value.IsOpen && port.Value.BytesToRead > 0 then
        let data = port.Value.ReadLine().Trim()
        printfn "📡 Received from Arduino: %s" data

// 🎯 Main Processing Loop
let rec mainLoop (ct: CancellationToken) =
    async {
        while not ct.IsCancellationRequested do
            try
                let startTime = Stopwatch.StartNew()

                // Capture screen & run YOLO model
                let! frameTask = captureScreenAsync () |> Async.AwaitTask
                let imageData = frameTask
                let results = runInferenceAsync imageData |> Async.RunSynchronously

                // Handle detection results
                match results with
                | detected when detected.Length > 0 ->
                    let xMid = detected.[0]
                    let yMid = detected.[1]
                    printfn "🎯 Detected target at: X = %.2f, Y = %.2f" xMid yMid
                    simulator.Mouse.MoveMouseBy(int xMid, int yMid) |> ignore
                | _ -> printfn "🚫 No targets detected."

                // Handle Serial Input from Arduino
                if port <> null && port.IsOpen && port.BytesToRead > 0 then
                    let data = port.ReadLine().Trim()
                    printfn "📡 Received from Arduino: %s" data
                    match data with
                    | "ENABLE_AIM" -> printfn "🎯 Assistive Aim Enabled"
                    | "DISABLE_AIM" -> printfn "🛑 Assistive Aim Disabled"
                    | "RESET" -> printfn "🔄 Resetting Aim Assist"
                    | "HELP" -> showHelpMessage()
                    | _ -> printfn "⚠️ Unknown command: %s" data

                // FPS & Latency Reporting
                frameCount <- frameCount + 1
                let elapsedTime = startTime.ElapsedMilliseconds
                if lastTime.ElapsedMilliseconds >= 1000 then
                    printfn "⚡ FPS: %d | Latency: %dms" frameCount elapsedTime
                    frameCount <- 0
                    lastTime.Restart()

                do! Async.Sleep(100)  // Allow other tasks to execute

            with ex ->
                printfn "❌ Error in main loop: %s" ex.Message
    }

// 🎮 Main Application Entry Point
[<EntryPoint>]
let main argv =
    printfn "🚀 Assistive Aim Guide is starting..."
    showHelpMessage ()
    let mutable continueRunning = true

    while continueRunning do
        match gameSelection() with
        | Some game ->
            printfn "🎯 Starting primary monitor capture for %s..." game
            Async.StartAsTask(mainLoop cts.Token) |> Async.AwaitTask |> ignore
            printfn "🔘 Press any key to exit or 'R' to restart..."
            match Console.ReadKey(true).Key with
            | ConsoleKey.R -> continueRunning <- true
            | _ -> continueRunning <- false
        | None -> 
            printfn "❌ No game selected. Open a game and press any key to retry or 'E' to exit."
            match Console.ReadKey(true).Key with
            | ConsoleKey.E -> continueRunning <- false
            | _ -> ()
    
    // Ensure proper cleanup before exiting
    printfn "🔄 Shutting down..."
    cts.Cancel() // Stop the main loop safely
    if port <> null && port.IsOpen then port.Dispose()
    0 // Exit Code
