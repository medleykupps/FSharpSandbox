#time "on"

open System
open System.Net
open System.IO

let fetch callback url =
    let request = WebRequest.Create(Uri(url))
    use response = request.GetResponse()
    use stream = response.GetResponseStream()
    use reader = new IO.StreamReader(stream)
    callback reader url

let handle (reader:IO.StreamReader) url =
    let html = reader.ReadToEnd()    
    printfn "Content:\n%s" html
    html

// Not working - fix this
let fetchAsync urls callback =
    for url in urls do
        printfn "%s" url
        let content = fetch callback url
        content

let content = fetch handle "http://lead.service.csuat.com.au/v1/leads?email=sam.medley.222@carsales.com.au"

let baseUrls = [|"http://data.service.csuat.com.au/v1/items/";"http://data.service.csprd.com.au/v1/items/"|]

let networkId = "OAG-AD-1248147"

let urls = baseUrls |> Array.map(fun baseUrl -> String.Format("{0}{1}", baseUrl, networkId))

fetchAsync urls handle
