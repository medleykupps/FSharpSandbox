open System
open System.IO
open System.Text.RegularExpressions

let filenames = ["js/first.js";"js/second.js"]

let original = 
    "<script type='text/javascript'>
    $(function() {
        // Wanting to do something here
        var i = 10;
    })
    </script>
    <script type='text/javascript' src='js/first.js'></script>
    $(function() {
        // Some other code here...
        var j = 99;
    })
    <script type='text/javascript' src='js/second.js'></script>
    $(function() {
        // Another function
        var k = 99;
    })
"

let loadContent filename =
    File.ReadAllText filename    

let contents = 
    filenames
    |> List.map(fun filename -> (filename, loadContent filename) )
    |> List.iter(fun (filename, content) -> printfn "%s =\n%s" filename content)

let segments =
    original.Split([|"<script"|], StringSplitOptions.None)

//let m = Regex.Match(original, "<script[^>]*</script>")
let m = Regex.Matches(original, "<script.*</script>")

//List.iter (fun gvalue -> printfn "%s" gvalue) [for g in m.Groups -> g.Value]
// [for g in m.Groups -> printfn "%s" g.Value]
//[for capture in m.Captures -> printfn "%s" capture.Value]

let indices = 
    seq {
        for m1 in m do
            for group in m1.Captures do
                printfn "%s" group.Value
                yield group.Index
    }


//filenames
//|> List.iter(fun filename -> printfn "%s" filename)

//segments
//|> Array.iter(fun segment -> printfn "%s" segment)

//printfn "Original code to parse:\n%s" original

printfn "...done"
