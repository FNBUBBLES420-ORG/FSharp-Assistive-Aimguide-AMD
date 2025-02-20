/// Dummy module to indicate that this project is written in F#
module ProjectInfo

/// Message indicating the project's primary language
let projectLanguage = "This project is implemented in F# for high-performance and functional programming benefits."

/// Print the project language information
[<EntryPoint>]
let main argv =
    printfn "%s" projectLanguage
    0
