namespace FifthHomework

type Windows() =
    interface IOperatingSystem with
        member _.Name = "Windows"
        member _.InfectionProbability = 0.6