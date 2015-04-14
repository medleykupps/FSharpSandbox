namespace Pedrera.FSharpSandbox.Core

type Aspect = 
    {
        Id: int
        Name: string
        DisplayName: string
        Type: string
    }

    member x.ToExpression (value) =
        "Name=[" + value + "]"
