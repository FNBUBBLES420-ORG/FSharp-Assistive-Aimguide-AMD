module SerialCommunication

open System
open RJCP.IO.Ports

/// Serial port initialization with proper disposal handling
type SerialHandler(portName: string, baudRate: int) =
    let mutable isDisposed = false
    let serialPort = new SerialPortStream(portName, baudRate)

    /// Opens the serial port safely
    member this.OpenPort () =
        try
            if not serialPort.IsOpen then
                serialPort.Open()
                printfn "✅ Connected to Arduino Leonardo on %s" portName
        with
        | ex -> 
            printfn "❌ Error opening serial port: %s" ex.Message

    /// Closes the serial port safely
    member this.ClosePort () =
        if serialPort.IsOpen then
            serialPort.Close()
            printfn "🔌 Serial port closed."

    /// Sends a command to the Arduino safely
    member this.SendCommand (cmd: string) =
        async {
            try
                lock serialPort (fun () ->
                    if serialPort.IsOpen then
                        serialPort.WriteLine(cmd)
                        printfn "📡 Command sent: %s" cmd
                    else
                        printfn "⚠️ Serial port is not open, unable to send command."
                )
            with
            | ex -> printfn "❌ Failed to send command: %s" ex.Message
        }

    /// Reads data from the Arduino safely
    member this.ReadPort () =
        async {
            try
                let result = 
                    lock serialPort (fun () ->
                        if serialPort.IsOpen && serialPort.BytesToRead > 0 then
                            let data = serialPort.ReadLine().Trim()
                            printfn "📥 Received from Arduino: %s" data
                            Some data
                        else
                            None
                    )
                return result
            with
            | ex -> 
                printfn "❌ Failed to read from port: %s" ex.Message
                return None
        }

    interface IDisposable with
        /// Ensures proper cleanup and resource disposal
        member this.Dispose() =
            if not isDisposed then
                isDisposed <- true
                this.ClosePort()
                serialPort.Dispose()
                printfn "🗑️ SerialHandler disposed."
