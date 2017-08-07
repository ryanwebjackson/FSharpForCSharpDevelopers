namespace main

open System

module Program =

    [<EntryPoint>]
    let main argv = 
        //printfn "%A" argv //accept program input arguments

        printfn "sum value after compilation: %i" Chapter1.sum

        Console.ReadLine() |> ignore
        0 // return an integer exit code
