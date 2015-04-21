open System
open System.Data
open System.Data.SqlClient

#load "./Rainbow.fsx"
#load "/Code/Globs/ConnStrings.fsx"

// let boatsales = Rainbow.portals |> List.find(fun p -> p.PortalAlias.Equals("boatsalesau"))
// let bikesales = Rainbow.Portal.Bikesales
// bikesales.PortalId

type RewriteTarget = { Id: int; Name: string; TemplateUrl: string; Location: string;}

let getResult<'a> sql (getItemFromReader : SqlDataReader -> 'a) = 
    use connection = new SqlConnection(ConnStrings.ScarlettDevConnectionString)
    let command = new SqlCommand(sql, connection)
    try
        connection.Open()
        use reader = command.ExecuteReader()
        printfn "Using the reader"
        let records =
            [|
                while reader.Read() do
                    yield getItemFromReader reader                    
            |]
        records
    with
        | ex -> 
            printfn "Exception: %s" ex.Message
            Array.empty<'a>

let parseRewriteTarget (sqlReader:SqlDataReader) =
    { 
        Id = Int32.Parse(sqlReader.[0].ToString()); 
        Name = sqlReader.[1].ToString(); 
        TemplateUrl = sqlReader.[2].ToString(); 
        Location = sqlReader.[3].ToString() 
    }    

let bikesaleResults = getResult (String.Format("SELECT Id, Name, TemplateUrl, Location FROM tbRewriteTargets WHERE PortalId = {0}", int Rainbow.Portal.Bikesales.PortalId)) parseRewriteTarget

for item in bikesaleResults do
    printfn "%d: %s\n\t%s\n\t%s" item.Id item.Name item.TemplateUrl item.Location


//printfn "%s" boatsales.PortalAlias
