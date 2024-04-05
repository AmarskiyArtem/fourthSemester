module FourthHomework.Brackets

let isBalanced (input: string) =
    let matchingBrackets = Map.ofList [('[', ']'); ('{', '}'); ('(', ')')]
    let isOpeningBracket c = matchingBrackets.ContainsKey(c)
    let isMatchingBracket stackChar closeChar =
        matchingBrackets.TryFind(stackChar).Value = closeChar

    let rec check stack chars =
        match chars with
        | [] -> List.isEmpty stack
        | c :: rest when isOpeningBracket c -> check (c :: stack) rest
        | c :: rest ->
            match stack with
            | [] -> false
            | openChar :: remainingStack ->
                if isMatchingBracket openChar c then
                    check remainingStack rest
                else
                    false

    check [] (List.ofSeq input)