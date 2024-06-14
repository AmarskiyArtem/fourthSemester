module FourthHomework.Tests.PhonebookTests

open FourthHomework.Phonebook

open NUnit.Framework

open FsUnit

[<Test>]
let ``addContact should add a contact to the phonebook`` () =
    let phonebook: Phonebook = []
    let contact: Contact = ("John Doe", "1234567890")
    let newPhonebook = addContact contact phonebook
    newPhonebook |> should equal [contact]
    let newContact: Contact = ("Jane Doe", "0987654321")
    let newPhonebook = addContact newContact newPhonebook
    newPhonebook |> should equal [newContact; contact]

[<Test>]
let ``read from file should correct phonebook`` () =
    let path = "../../../test.txt"
    let phonebook = readFromFile path
    phonebook |> should equal [("bigman", "123456"); ("halfman", "11")]

[<Test>]
let ``findByName should return the correct contact`` () =
    let path = "../../../test.txt"
    let phonebook = readFromFile path
    let contact = findByName "bigman" phonebook
    contact |> Option.get |> should equal "123456"
    let contact = findByName "halfman" phonebook
    contact |> Option.get |> should equal "11"

[<Test>]
let ``findByNumber should return the correct contact`` () =
    let path = "../../../test.txt"
    let phonebook = readFromFile path
    let contact = findByNumber "123456" phonebook
    contact |> Option.get |> should equal "bigman"
    let contact = findByNumber "11" phonebook
    contact |> Option.get |> should equal "halfman"