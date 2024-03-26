module SecondHomework.EvenNumbers

let CountEvenNumbersFilter lst =
    lst |> List.filter(fun x -> x % 2 = 0) |> List.length

let CountEvenNumbersMap lst =
    lst |> List.map(fun x -> if x % 2 = 0 then 1 else 0) |> List.sum

let CountEvenNumbersFold lst =
    List.fold(fun acc x -> if x % 2 = 0 then acc + 1 else acc) 0 lst