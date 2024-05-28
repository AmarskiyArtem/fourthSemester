module SecondHomework.EvenNumbers

let countEvenNumbersFilter lst =
    lst |> List.filter(fun x -> x % 2 = 0) |> List.length

let countEvenNumbersMap lst =
    lst |> List.map(fun x -> if x % 2 = 0 then 1 else 0) |> List.sum

let countEvenNumbersFold lst =
    lst |> List.fold(fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0