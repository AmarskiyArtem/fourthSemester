module SecondHomework.InfPrime

let IsPrime x =
    if x < 2 then false
    else
        let sqrtOfX = sqrt (float x)
        let rec f a =
            match a with
            | _ when float a > sqrtOfX -> true 
            | _ when x % a = 0 -> false
            | _ -> f (a + 1)
        f 2

let AllPrimes =
    Seq.initInfinite id |> Seq.filter IsPrime