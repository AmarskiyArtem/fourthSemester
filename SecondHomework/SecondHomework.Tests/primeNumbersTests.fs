
module PrimeNumberGeneratorTests

open NUnit.Framework
open FsUnit
open SecondHomework.InfPrime

let Data () = 
    [   
        1, seq{2}
        2, seq{2; 3}
        10, seq{2; 3; 5; 7; 11; 13; 17; 19; 23; 29}
    ]
    |> List.map (fun (number, seq) -> TestCaseData(number, seq))


[<TestCaseSource("Data")>]
let generatePrimeNumbersTests number expected =  
    AllPrimes |> Seq.take number |> should equal expected