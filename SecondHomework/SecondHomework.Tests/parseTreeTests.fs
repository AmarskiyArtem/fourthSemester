module SecondHomework.ParsingTree.Tests

open NUnit.Framework
open FsUnit
open SecondHomework.ParsingTree

[<Test>]
let ``computeTree should return value of Leaf``() =
    let tree = Leaf 5.0
    let result = computeTree tree
    result |> should equal 5.0

[<Test>]
let ``computeTree should correctly compute simple operations``() =
    let tree = Node('+', Leaf 2.0, Leaf 3.0)
    let result = computeTree tree
    result |> should equal 5.0

[<Test>]
let ``computeTree should correctly compute operations``() =
    let tree = Node('*', Node('+', Leaf 2.0, Leaf 3.0), Leaf 4.0)
    let result = computeTree tree
    result |> should (equalWithin 0.001) 20.0

[<Test>]
let ``computeTree should correctly compute operations with negative numbers``() =
    let tree = Node('-', Leaf 2.0, Leaf 3.0)
    let result = computeTree tree
    result |> should equal -1.0

[<Test>]
let ``computeTree should correctly compute operations with division``() =
    let tree = Node('/', Leaf 6.0, Leaf 3.0)
    let result = computeTree tree
    result |> should (equalWithin 0.001) 2.0