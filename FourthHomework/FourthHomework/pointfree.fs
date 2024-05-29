module FourthHomework.Pointfree

let func x l = 
    List.map (fun y -> y * x) l

let func2 x =
    List.map (fun y -> y * x)

let func3 x =
    List.map ((*) x)

let funcFinal =
    List.map << (*)