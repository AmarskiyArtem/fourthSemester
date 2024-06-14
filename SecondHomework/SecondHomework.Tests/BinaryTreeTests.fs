module SecondHomework.BinaryTree.Tests

open NUnit.Framework
open FsUnit
open SecondHomework.BinaryTree

[<Test>]
let ``mapTree should return Leaf when given Leaf``() =
    let tree = Leaf
    let result = mapTree (fun x -> x) tree
    result |> should equal Leaf

[<Test>]
let ``mapTree should apply function to all nodes in the tree``() =
    let tree = Node(1, Node(2, Leaf, Leaf), Node(3, Leaf, Leaf))
    let result = mapTree ((*) 2) tree
    let expected = Node(2, Node(4, Leaf, Leaf), Node(6, Leaf, Leaf))
    result |> should equal expected