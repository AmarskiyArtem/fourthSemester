namespace FifthHomework

open System
open System.Collections.Generic

type Network(adjacencyMatrix: int[,], computers: Computer list) =
    let n = adjacencyMatrix.GetLength(0)

    let rnd = Random()

    member val Computers = computers with get

    member this.Infect (computer: Computer) =
        if not computer.IsInfected && rnd.NextDouble() <= computer.OS.InfectionProbability then
            computer.IsInfected <- true

    member this.Step () =
        let newlyInfected = new List<Computer>()
        for i in 0 .. n - 1 do
            if computers.[i].IsInfected then
                for j in 0 .. n - 1 do
                    if adjacencyMatrix.[i, j] = 1 && not computers.[j].IsInfected then
                        if rnd.NextDouble() <= computers.[j].OS.InfectionProbability then
                            newlyInfected.Add(computers.[j])
        
        for comp in newlyInfected do
            comp.IsInfected <- true

    member this.PrintState () =
        for computer in computers do
            printfn "Computer %d [%s] - %s" computer.Id computer.OS.Name (if computer.IsInfected then "Infected" else "Clean")