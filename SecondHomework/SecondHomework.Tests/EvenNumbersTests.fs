module SecondHomework.EvenNumbersTests

open SecondHomework.EvenNumbers
open NUnit.Framework
open FsUnit
open FsCheck


let Data() = 
    [
        [-4 .. 4], 5
        [1 .. 100], 50
        [], 0
        [1; 3; 5; 7; 9], 0
    ] |> List.map (fun (lst, expected) -> TestCaseData(lst, expected))


[<TestCaseSource("Data")>]
let ``MapCounter should expected result`` lst expected =
    countEvenNumbersMap lst |> should equal expected


[<Test>]
let ``even numbers funs should be equivalent``() =
    let areEquivalent lst = 
        let filterResult = countEvenNumbersFilter lst
        let mapResult = countEvenNumbersMap lst
        let foldResult = countEvenNumbersFold lst
        let x = mapResult = filterResult
        let y = foldResult = filterResult
        x && y
    Check.QuickThrowOnFailure areEquivalent