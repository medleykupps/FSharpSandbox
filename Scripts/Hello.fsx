open System

let version = "0.0.1"

printfn "Running Hello.fsx script\nVersion: %s" version

type Person =
    {
        Id: int
        Name: string
    }

type Customer (id: int, name: string) =
    do printfn "%d" id
    new() = Customer(999, "Unknown")
    new(id:int) = Customer(id, "Unknown")
    member this.Id = id
    member this.Name = name

//??? Expects a Person and not a Customer
let doSomething p =
    printfn "%d %s" p.Id p.Name



let c1 = Customer()
let c2 = Customer(13)
let c3 = Customer(50, "Dummy")


let result = doSomething c1



printfn "Exiting"
