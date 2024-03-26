module SecondHomework.ParsingTree

type ParsingTree =
    | Leaf of float
    | Node of char * ParsingTree * ParsingTree

let rec computeTree tree =
    match tree with
    | Leaf value -> value
    | Node (operator, left, right) ->
        match operator with
        | '+' -> computeTree left + computeTree right
        | '-' -> computeTree left - computeTree right
        | '*' -> computeTree left * computeTree right
        | '/' -> computeTree left / computeTree right
        | _ -> failwith "Unsupported operator"