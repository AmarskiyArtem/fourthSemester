module ThirdHomework.Tests

open NUnit.Framework
open FsUnit
open BetaReduction

let Expressions () =
    [
        Application(
            Abstraction("x", Var "y"),
            Application(
                Abstraction("x", Application(Var "x", Application(Var "x", Var "x"))),
                Abstraction("x", Application(Var "x", Application(Var "x", Var "x")))
            )
        ), Var "y"
        Application(Abstraction("x", Var "x"), Var "y"), Var "y"
        Application(
            Abstraction(
                "f",
                Abstraction(
                    "x",
                    Application(Application(Var "f", Var "x"), Var "x"))
            ),
            Var "+"
        ), Abstraction("x", Application(Application(Var "+", Var "x"), Var "x"))
    ]|> List.map (fun (term, normForm) -> TestCaseData(term, normForm))


[<TestCaseSource(nameof Expressions)>]
let betaReduceTests expression expected  =  
    betaReduce expression |> should equal expected