// LICENSE
// This project is proprietary and all rights are reserved by the author.
// Unauthorized copying, distribution, or modification of this project is strictly prohibited.
// Unless You have written permission from the Developer or the FNBUBBLES420 ORG.

module GPUProcessing

open System
open System.Management

/// Detect if an AMD GPU is available by querying WMI.
let hasAmdGpu () =
    try
        use searcher = new ManagementObjectSearcher("select * from Win32_VideoController")
        let results = searcher.Get()
        results
        |> Seq.cast<ManagementObject>
        |> Seq.exists (fun obj ->
            let name = obj.["Name"] :?> string
            name.ToLower().Contains("amd") || name.ToLower().Contains("radeon")
        )
    with
    | ex ->
        printfn "❌ Error detecting GPU: %s" ex.Message
        false

/// Detect and return the available GPU type: "AMD" if an AMD GPU is available, otherwise "CPU".
let detectGpuType () =
    if hasAmdGpu() then "AMD" else "CPU"

/// Simulated GPU memory type for AMD using DirectML (dummy type for demonstration).
type AmdMemory(data: float32[]) =
    member this.Data = data

/// Process tensor data on GPU based on detected hardware.
/// For AMD, this simulates processing via DirectML by wrapping the data in an AmdMemory object.
/// If no AMD GPU is detected, it falls back to CPU processing.
let processOnGpu (data: float32[]) =
    match detectGpuType() with
    | "AMD" ->
        printfn "✅ Using AMD DirectML for processing."
        // Simulate processing by wrapping the data in AmdMemory.
        new AmdMemory(data)
    | "CPU" ->
        printfn "⚠️ No AMD GPU detected! Using CPU processing."
        new AmdMemory(data)
    | _ ->
        printfn "⚠️ Unknown GPU type detected! Using CPU processing."
        new AmdMemory(data)
