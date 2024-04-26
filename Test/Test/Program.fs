module Test

let fibSumEven n =
    let rec fibHelper a b sum = 
        if b >= n then
            sum
        elif b % 2 = 0 then
            fibHelper b (a + b) (sum + b)
        else
            fibHelper b (a + b) sum
    fibHelper 1 1 0


let getSquare n =
    if n < 1 then
        ""
    else
        let rec helper i n str =
            match i with
            | _ when i = n -> String.concat "" [str; String.replicate n "*"]
            | _ when i = 1 -> helper (i + 1) n (String.concat "" [str; String.replicate n "*"; "\n"])
            | _ -> helper (i + 1) n (String.concat "" [str; "*"; String.replicate (n - 2) " "; "*"; "\n"])
        helper 1 n ""


type PriorityQueue<'T>() =
    let mutable elements : List<'T * int> = []

    member this.Enqueue(value: 'T, priority: int) =
        elements <- (value, priority) :: elements

    member this.Dequeue() =
        if List.isEmpty elements then
            failwith "Queue is empty"
        let maxPriority = elements |> List.minBy snd |> snd
        elements <- elements |> List.filter (fun (_, p) -> p <> maxPriority)
        maxPriority

printfn "Сумма чётных чисел Фибоначчи до 1 000 000: %d" (fibSumEven 1000000)

printfn "Квадрат из * со стороной 5"

getSquare 5 |> printfn "%s"