Viktigt att tänka på!!:

När Migrations ska köras så behöver det i nuläget köras från solution-mappen och ange 
API-projektet som startprojekt i PowerShell. Detta för att migrationsverktyget ska hitta databasen!
appsettings.json finns i API-projektet och det är där connectionstringen finns.

Enligt följande alltså:
dotnet ef migrations add InitialCreate --project ProjectManagementApp.Infrastructure --startup-project ProjectManagementApp.API

Infrastructure har ingen appsettings.json, så migration hittar inte databasen
Kanske går att fixa genom att ha API som StartUp-Project som standard? 

API:
Har följande filer: 
- appsettings.json
- Program.cs

Infrastructure:

Core: