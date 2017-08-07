open System

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    Console.ReadLine() |> ignore
    0 // return an integer exit code
