
* API (Presentation) 
- WebApi
- Controllers/ som tar emot http-anrop och hanterar API-logik. (ProjectController.cs + CustomerController.cs)
- appsettings.json (konfigurationsfil)
- Program.cs (startar applikationen)
- ProjectManagementApp.API.http (testfil för att testa API:et)

* Core (Domain layer)
- Entities/ som innehåller domänmodeller (Project.cs + Customer.cs + ProjectManager.cs + ServiceType.cs)
- Interfaces/ som innehåller gränssnitt (ICustomerService.cs + IProjectService.cs)

* Infrastructure (Data Access Layer)
- Services/ som innehåller tjänster för att hantera data (CustomerService.cs + ProjectService.cs)
- Repositories/ som innehåller repositories för att hantera data (CustomerRepository.cs + ProjectRepository.cs)


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