module FourthHomework.Phonebook

type Contact = string * string

type Phonebook = Contact list

let addContact (contact: Contact) (phonebook: Phonebook) =
    contact :: phonebook

let findByName (name: string) (phonebook: Phonebook) =
    phonebook
    |> List.tryFind (fun (n, _) -> n = name)
    |> Option.map snd

let findByNumber (number: string) (phonebook: Phonebook) =
    phonebook
    |> List.tryFind (fun (_, n) -> n = number)
    |> Option.map fst

let printPhonebook (phonebook: Phonebook) =
    phonebook
    |> List.iter (fun (n, p) -> printfn "%s: %s" n p)

let readFromFile (path: string) =
    System.IO.File.ReadAllLines path
    |> Array.toList
    |> List.map (fun line -> 
        let parts = line.Split(':')
        (parts.[0], parts.[1])
    )

let writeToFile (path: string) (phonebook: Phonebook) =
    let text = 
        phonebook |> List.map (fun (n, p) -> sprintf "%s:%s" n p) 
        |> String.concat "\n"

    System.IO.File.WriteAllText(path, text)