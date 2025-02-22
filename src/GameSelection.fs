// LICENSE
// This project is proprietary and all rights are reserved by the author.
// Unauthorized copying, distribution, or modification of this project is strictly prohibited.
// Unless You have written permission from the Developer or the FNBUBBLES420 ORG.

module GameSelection

open System
open System.Diagnostics

/// Auto-detects running games from a predefined list and lets the user select one.
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

