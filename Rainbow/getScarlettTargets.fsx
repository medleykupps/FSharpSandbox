open System
open System.Data
open System.Data.SqlClient

#load "./Rainbow.fsx"

// let boatsales = Rainbow.portals |> List.find(fun p -> p.PortalAlias.Equals("boatsalesau"))
// let bikesales = Rainbow.Portal.Bikesales
// bikesales.PortalId

let getResult sql getItemFromReader = 
    use connection = new SqlConnection(Rainbow.ScarlettDevConnectionString)
    let command = new SqlCommand(sql, connection)
    try
        connection.Open()
        use reader = command.ExecuteReader()
        printfn "Using the reader"
        while reader.Read() do
            getItemFromReader reader
        1
    with
        | :? Exception as ex -> 
            printfn "Exception: %s" ex.Message
            0

let rewriteCallback sqlReader : SqlDataReader =
    let id = sqlReader.[0].ToString()
    let name = sqlReader.[1].ToString()
    printfn "%s: %s" id name

let result = getResult (String.Format("SELECT TOP 10 Id, Name FROM tbRewriteTargets WHERE PortalId = {0}", int Rainbow.Portal.Bikesales.PortalId)) rewriteCallback



//printfn "%s" boatsales.PortalAlias
