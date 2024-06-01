namespace FifthHomework

type MacOS() =
    interface IOperatingSystem with
        member _.Name = "MacOS"
        member _.InfectionProbability = 0.1