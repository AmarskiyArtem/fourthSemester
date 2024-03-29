module BetaReduction

type LambdaTerm =
    | Var of string
    | Abstraction of string * LambdaTerm
    | Application of LambdaTerm * LambdaTerm

let rec freeVars term =
    match term with
    | Var v -> Set.singleton v
    | Abstraction (v, t) -> Set.remove v (freeVars t)
    | Application (t1, t2) -> Set.union (freeVars t1) (freeVars t2)

let isFree v term = Set.contains v (freeVars term)

let rec newVar usedVars =
    let rec freshVar' v =
        if Set.contains v usedVars then freshVar' v + "x"
        else v
    freshVar' "x"

let rec substitute x baseTerm term =
    match baseTerm with
    | Var y when x = y -> term
    | Var _ -> baseTerm
    | Application (s1, s2) -> Application (substitute x s1 term, substitute x s2 term)
    | Abstraction (y, _) when y = x -> baseTerm
    | Abstraction (y, t) 
        when not(isFree y term && isFree x t) -> Abstraction (y, substitute x t term)
    | Abstraction (y, t) ->
        let z = newVar (Set.union (freeVars term) (freeVars t))
        Abstraction (z, substitute x (substitute y t (Var z)) term)


let rec betaReduce term =
    match term with
    | Var v -> Var v
    | Application (Abstraction (v, t), t') -> substitute v t' t
    | Application (t1, t2) -> Application (betaReduce t1, betaReduce t2)
    | Abstraction (v, t) -> Abstraction (v, betaReduce t)
