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