module Test.Tests

open NUnit.Framework
open FsUnit
open Test


[<Test>]
let ``When n is -1, fibSumEven should return 0`` () =
    let result = fibSumEven -1
    result |> should equal 0

[<Test>]
let ``When n is 10, fibSumEven should return 10`` () =
    let result = fibSumEven 10
    result |> should equal 10

[<Test>]
let ``When n is 1.000.000, fibSumEven should return 1089154`` () =
    let result = fibSumEven 10
    result |> should equal 10


[<Test>]
let ``When n is 2, fibSumEven should return 0`` () =
    let result = fibSumEven 2
    result |> should equal 0


[<Test>]
let ``getSquare should return empty string when n is 0`` () =
    let result = getSquare 0
    result |> should equal ""

[<Test>]
let ``getSquare should return * when n is 1`` () =
    let result = getSquare 1
    result |> should equal "*"

[<Test>]
let ``getSquare should return rightFigure when n is 2`` () =
    let result = getSquare 2
    result |> should equal "**\n**"

[<Test>]
let ``getSquare should return rightFigure when n is 4`` () =
    let result = getSquare 4
    result |> should equal "****\n*  *\n*  *\n****"