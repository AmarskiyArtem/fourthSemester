namespace FifthHomework

type Linux() =
    interface IOperatingSystem with
        member _.Name = "Linux"
        member _.InfectionProbability = 0.3