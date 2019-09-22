// Listing 7-31: Finding the LCA (Lowest Common Ancestor) in a BST (Binary Search Tree)
type NodeType = int

type BinaryTree =
    | Nil
    | Node of NodeType * BinaryTree * BinaryTree

let createBinaryTree() =
    Node(20, 
        Node(8, 
            Node(5, Nil, Nil),
            Node(12, Node(11, Nil, Nil), Node(15, Nil, Nil))
            ),
        Node(30, Node(21, Nil, Nil), Node(32, Nil, Nil))
    )

let tree = createBinaryTree()

let rec findLCAinBST (n0, n1) root = 
    match root with
    | Nil -> None
    | Node(v, left, right) ->
        if v >= n0 && v <= n1 then
            Some v
        elif v > n0 && v > n1 then
            findLCAinBST (n0, n1) left
        else
            findLCAinBST (n0, n1) right

tree |> findLCAinBST (3, 15)

//Listing 7-52: A simple XOR neural network implementation
namespace FSharp.NN

open System
open System.Collections.Generic

type NeuralFactor(weight:float) =
    member val HVector = 0. with get, set
    member val Weight = weight with get, set

    // [RWJ] What is the difference between 'member val' and 'member this' syntax?
    member this.SetWeightChange rate =
        this.Weight <- this.Weight + this.HVector * rate

    member this.Reset() =
        this.HVector <- 0

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
        this.Output <- 0
        for item in this.Input do
            this.Output <- this.Output + item.Key.Output * item.Value.Weight
        this.Output <- this.Output + this.Bias.Weight
        this.Output <- sigmoid this.Output

    member this.ApplyLearning rate = 
        for value in this.INput.Values do
            value.SetWeirghtChange rate

        this.Bias.SetWeightChange rate

    member this.Initialize() =
        this.Input.Values
        |> Seq.iter (fun value -> value.Reset())

        this.Bias.Reset()

    override this.ToString()
        sprintf "(Bias=%A, Error=%A, Output=%A)" this.Bias this.Error this.Output

