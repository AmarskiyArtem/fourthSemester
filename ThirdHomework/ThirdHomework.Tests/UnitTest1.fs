module ThirdHomework.Tests

open NUnit.Framework
open FsUnit
open BetaReduction

let Expressions () =
    [
        Application(
            Abstraction("x", Variable "y"),
            Application(
                Abstraction("x", Application(Variable "x", Application(Variable "x", Variable "x"))),
                Abstraction("x", Application(Variable "x", Application(Variable "x", Variable "x")))
            )
        ), Variable "y"
        Application(Abstraction("x", Variable "x"), Variable "y"), Variable "y"
        Application(
            Abstraction(
                "f",
                Abstraction(
                    "x",
                    Application(Application(Variable "f", Variable "x"), Variable "x"))
            ),
            Variable "+"
        ), Abstraction("x", Application(Application(Variable "+", Variable "x"), Variable "x"))
    ]|> List.map (fun (term, normForm) -> TestCaseData(term, normForm))


[<TestCaseSource(nameof Expressions)>]
let betaReduceTests expression expected  =  
    betaReduce expression |> should equal expected