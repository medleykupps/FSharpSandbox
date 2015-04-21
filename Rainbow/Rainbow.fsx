open System

type PortalId = 
    Bikesales = 140964 | Bikepoint = 521967

type Portal (id : PortalId, alias : string) =
    member x.PortalId = id
    member x.PortalAlias = alias
    static member Bikesales = Portal(PortalId.Bikesales, "bikesaleau")

let portals = [
    Portal(PortalId.Bikesales, "bikesalesau");
    Portal(PortalId.Bikepoint, "bikepointau");
//    Portal(684329, "boatsalesau");
//    Portal(684382, "boatpointau");
//    Portal(602300, "caravancampingsalesau");
//    Portal(602480, "constructionsalesau");
//    Portal(684427, "equipmentsalesau");
//    Portal(602489, "farmmachinerysalesau");
//    Portal(602467, "trucksalesau");
]


let ScarlettProductionConnectionString = "server=stg-ho-sql-02s;database=Scarlett;Trusted_Connection=true;";
let ScarlettDevConnectionString = "server=cssvrstgsql2;database=Scarlett;Trusted_Connection=true;";
