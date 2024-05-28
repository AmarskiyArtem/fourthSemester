module SecondHomework.InfPrime

let isPrime x =
    if x < 2 then false
    else
        let sqrtOfX = sqrt (float x)
        let rec helper number =
            match number with
            | _ when float number > sqrtOfX -> true 
            | _ when x % number = 0 -> false
            | _ -> helper (number + 1)
        helper 2

let allPrimes =
    Seq.initInfinite id |> Seq.filter isPrime