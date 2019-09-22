//Listing 7-52: A simple XOR neural network implementation

//https://github.com/dotnet/fsharp/issues/3409
//namespace FSharp.NN

open System
open System.Collections.Generic

type NeuralFactor(weight:float) =
    member val HVector = 0. with get, set
    member val Weight = weight with get, set

    // [RWJ] What is the difference between 'member val' and 'member this' syntax?
    member this.SetWeightChange rate =
        this.Weight <- this.Weight + this.HVector * rate

    member this.Reset() =
        this.HVector <- 0.

    override this.ToString() =
        sprintf "(HVector=%A, Weight=%A)" this.HVector this.Weight

type Map = Dictionary<Neuron, NeuralFactor>

and Neuron(bias) =
    let sigmoid v = 1. / (1. + exp(-v))

    member val Bias = NeuralFactor(bias) with get, set
    member val Error = 0. with get, set
    member val Input = Map() with get, set
    member val LastError = 0. with get, set

    member val Output = 0. with get, set

    member this.Pulse() =
        this.Output <- 0.
        for item in this.Input do
            this.Output <- this.Output + item.Key.Output * item.Value.Weight
        this.Output <- this.Output + this.Bias.Weight
        this.Output <- sigmoid this.Output

    member this.ApplyLearning rate = 
        for value in this.Input.Values do
            value.SetWeightChange rate

        this.Bias.SetWeightChange rate

    member this.Initialize() =
        this.Input.Values
        |> Seq.iter (fun value -> value.Reset())

        this.Bias.Reset()

    override this.ToString() =
        sprintf "(Bias=%A, Error=%A, Output=%A)" this.Bias this.Error this.Output

// Layer in the neural network
type NeuralLayer() =
    inherit List<Neuron>()
    member this.Pulse() =
        this |> Seq.iter (fun n -> n.Pulse())
    member this.Apply rate =
        this |> Seq.iter (fun n -> n.ApplyLearning rate)
    member this.Initialize() =
        this |> Seq.iter (fun n -> n.Initialize())

//TODO: Create 'NeuralNetwork' higher-level type -- Layer container.