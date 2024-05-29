module Program

open System

open FourthHomework.Phonebook

let displayMenu() =
    printfn "Phone Book Menu"
    printfn "1. Add Contact"
    printfn "2. Search Contact"
    printfn "3. Delete Contact"
    printfn "4. Display All Contacts"
    printfn "5. Help"
    printfn "6. Read from file"
    printfn "7. Write to file"
    printfn "8. Exit"

let rec main phonebook =

    let choice = Console.ReadLine()

    match choice with
    | "1" ->
        printfn "Enter the contact name:"
        let name = Console.ReadLine()
        printfn "Enter the contact number:"
        let number = Console.ReadLine()
        let newContact: Contact = (name, number)
        printfn "Contact added successfully.\n"
        main (addContact newContact phonebook)
    | "2" ->
        printfn "Enter the contact name to search:"
        let name = Console.ReadLine()
        let result = findByName name phonebook
        match result with
        | Some number ->
            printfn "Contact found: %s - %s" name number
        | None ->
            printfn "Contact not found."
        main phonebook
    | "3" ->
        printfn "Enter the contact number to search:"
        let number = Console.ReadLine()
        let result = findByNumber number phonebook
        match result with
        | Some name ->
            printfn "Contact found: %s - %s" name number
        | None ->
            printfn "Contact not found."
        main phonebook
    | "4" ->
        printPhonebook phonebook
        main phonebook
    | "5" ->
        displayMenu()
        main phonebook
    | "6" ->
        printfn "Enter the file path:"
        let path = Console.ReadLine()
        let contacts = readFromFile path
        printfn "Contacts read from file."
        main contacts
    | "7" ->
        printfn "Enter the file path:"
        let path = Console.ReadLine()
        writeToFile path phonebook
        printfn "Contacts written to file."
        main phonebook
    | "8" ->
        printfn "Exiting..."
    | _ ->
        printfn "Invalid choice. Please try again."
        main phonebook

displayMenu()

main []