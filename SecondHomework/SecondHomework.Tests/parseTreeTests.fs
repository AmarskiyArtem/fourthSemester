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
    result |> should equal 20.0

[<Test>]
let ``computeTree should fail with unsupported operator``() =
    let tree = Node('x', Leaf 2.0, Leaf 3.0)
    Assert.Throws<System.Exception>(fun () -> computeTree tree |> ignore)