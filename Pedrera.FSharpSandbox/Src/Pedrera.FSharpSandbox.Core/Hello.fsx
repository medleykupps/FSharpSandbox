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

let emptyName : string option = None
let firstName : string option = Some("Sam")

printfn "Name: '%s'" <| 
    match emptyName with
        | Some(s) -> s
        | None -> "<Nothing>"

printfn "Name: '%s'" <| 
    match firstName with
        | Some(s) -> s
        | None -> "<Nothing>"

// Take the Fibonacci sequence and transform based on the match expression
let resultNums = 
    [|1;1;2;3;5;8;11;19|] |> 
        Array.map(
            fun num -> 
                let resultNum =            
                    match num with
                    | n when n % 2 = 0 -> n
                    | n when n = 11 -> 99
                    | _ -> num * 2
                printfn "%i => %i" num resultNum
                resultNum
        )

printfn "Exiting"
