namespace FifthHomework.Tests

open FifthHomework
open NUnit.Framework
open FsUnit

module Tests = 
    type BlackBerry() =
        interface IOperatingSystem with
            member _.Name = "BlackBerry"
            member _.InfectionProbability = 0

    type SDEK() =
        interface IOperatingSystem with
            member _.Name = "SDEK"
            member _.InfectionProbability = 1

    [<Test>]
    let ``All zeros should nothing change`` () =
        let fullyConnectedGraph = array2D [
            [1; 1; 1]
            [1; 1; 1]
            [1; 1; 1]
        ]
        let computers = [
            Computer(0, BlackBerry(), false)
            Computer(1, BlackBerry(), false)
            Computer(2, BlackBerry(), false)
            Computer(3, BlackBerry(), false)
            Computer(4, BlackBerry(), false)
        ]
        for i in 0..100 do
            let network = Network(fullyConnectedGraph, computers)
            network.Step()
            for computer in network.Computers do
                computer.IsInfected |> should equal false
        
    [<Test>]
    let ``All ones should bfs`` () =
        let graph = array2D [
            [0; 1; 0; 0; 0; 0; 0]
            [1; 0; 1; 1; 1; 0; 0]
            [0; 1; 0; 0; 0; 0; 0]
            [0; 1; 0; 0; 0; 1; 1]
            [0; 1; 0; 1; 0; 0; 1]
            [0; 0; 0; 0; 1; 1; 0]
        ]
        let computers = [
            Computer(0, SDEK(), true)
            Computer(1, SDEK(), false)
            Computer(2, SDEK(), false)
            Computer(3, SDEK(), false)
            Computer(4, SDEK(), false)
            Computer(5, SDEK(), false)
        ]
        let network = Network(graph, computers)
        network.Step()
        let state1 = [true; true; false; false; false; false]
        for i in 0..5 do
            network.Computers.[i].IsInfected |> should equal state1.[i]
        network.Step()
        let state2 = [true; true; true; true; true; false]
        for i in 0..5 do
            network.Computers.[i].IsInfected |> should equal state2.[i]
        network.Step()
        let state3 = [true; true; true; true; true; true]
        for i in 0..5 do
            network.Computers.[i].IsInfected |> should equal state3.[i]