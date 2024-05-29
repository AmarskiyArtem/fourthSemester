module FourthHomework.BracketBalanceTests

open NUnit.Framework
open FsUnit

open FourthHomework.BracketBalance

let Data () = 
    [   
        "", true
        "[{()}]", true
        "[{()}", false
        "[{(", false
        "})]", false
        "[{()}][{()}]", true
        "[{()}][{()}", false
        "[{()}(]", false
    ]
    |> List.map (fun (input, expected) -> TestCaseData(input, expected))

[<TestCaseSource("Data")>]
let ``String balance test`` (input, expected) =
    input |> isBalanced |> should equal expected
