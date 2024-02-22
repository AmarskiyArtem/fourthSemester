﻿let factorial n = 
    if n < 0 then invalidArg "n""n can't be negative" else
    let rec helper acc n =
        if n = 0 then acc
        else helper (acc * n) (n - 1)
    helper 1 n

let fibonacci n =
    if n < 0 then invalidArg "n""n can't be negative" else
    let rec helper a b n =
        if n = 0 then a
        else helper b (a + b) (n - 1)
    helper 0 1 n

let reverse ls =
    let rec helper donor recipient =
        if donor = [] then recipient
        else helper (List.tail donor) (List.head donor :: recipient)
    helper ls []



let x = reverse [1 .. 10]
printfn "%A" x
