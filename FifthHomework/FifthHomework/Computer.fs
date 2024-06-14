namespace FifthHomework

type Computer(id: int, os: IOperatingSystem, isInfected: bool) =
    member val Id = id with get
    member val OS = os with get
    member val IsInfected = isInfected with get, set