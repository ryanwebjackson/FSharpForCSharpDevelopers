namespace main

open System

module Program =

    [<EntryPoint>]
    let main argv = 
        //printfn "%A" argv //accept program input arguments

        printfn "Chapter 1: sum value after compilation: %i" Chapter1.sum

        printfn "CollectionFunctions.lengthTest [ 1..10 ]: %i" (CollectionFunctions.Sequence.lengthTest [1..10])

        Console.ReadLine() |> ignore
        0 // return an integer exit code
