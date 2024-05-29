module FourthHomework.PointfreeTests

open NUnit.Framework
open FsCheck

open FourthHomework.Pointfree

[<Test>]
let ``Are the functions equivalent`` () =
    let isCorrect x ls = func x ls = func2 x ls
    let isCorrect2 x ls = func2 x ls = func3 x ls
    let isCorrect3 x ls = func3 x ls = funcFinal x ls
    let isCorrect4 x ls = func x ls = funcFinal x ls

    Check.QuickThrowOnFailure isCorrect
    Check.QuickThrowOnFailure isCorrect2
    Check.QuickThrowOnFailure isCorrect3
    Check.QuickThrowOnFailure isCorrect4