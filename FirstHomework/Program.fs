let factorial n = 
    if n < 0 then invalidArg "n""n can't be negative" else
    let rec helper (acc:int) n =
        if n = 0 then acc
        else helper (acc * n) (n - 1)
    helper 1 n


printfn "%d" (factorial 10)