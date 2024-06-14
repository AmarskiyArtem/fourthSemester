module Test


// Calculates the sum of even Fibonacci numbers which less than n. 
// Returns the sum of even Fibonacci numbers.
let fibSumEven n =
    let rec fibHelper a b sum = 
        if b >= n then
            sum
        elif b % 2 = 0 then
            fibHelper b (a + b) (sum + b)
        else
            fibHelper b (a + b) sum
    fibHelper 1 1 0


// Returns a string with a square of * with a side of n.
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


// A priority queue implementation.
type PriorityQueue<'T>() =
    let mutable elements : List<'T * int> = []

    // Adds an element to the queue with a priority.
    member this.Enqueue(value: 'T, priority: int) =
        elements <- List.sortBy snd (elements @ [(value, priority)])

    // Removes the element with the highest priority from the queue.
    member this.Dequeue() =
        if List.isEmpty elements then
            failwith "Queue is empty"
        else
            let result = List.head elements
            elements <- List.tail elements
            fst result

printfn "Сумма чётных чисел Фибоначчи до 1 000 000: %d" (fibSumEven 1000000)

printfn "Квадрат из * со стороной 5"

getSquare 5 |> printfn "%s"