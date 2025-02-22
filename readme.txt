
* API (Presentation) 
- WebApi
- Controllers/ som tar emot http-anrop och hanterar API-logik. (ProjectController.cs + CustomerController.cs)
- appsettings.json (konfigurationsfil)
- Program.cs (startar applikationen)
- ProjectManagementApp.API.http (testfil f�r att testa API:et)

* Core (Domain layer)
- Entities/ som inneh�ller dom�nmodeller (Project.cs + Customer.cs + ProjectManager.cs + ServiceType.cs)
- Interfaces/ som inneh�ller gr�nssnitt (ICustomerService.cs + IProjectService.cs)

* Infrastructure (Data Access Layer)
- Services/ som inneh�ller tj�nster f�r att hantera data (CustomerService.cs + ProjectService.cs)
- Repositories/ som inneh�ller repositories f�r att hantera data (CustomerRepository.cs + ProjectRepository.cs)


Viktigt att t�nka p�!!:

N�r Migrations ska k�ras s� beh�ver det i nul�get k�ras fr�n solution-mappen och ange 
API-projektet som startprojekt i PowerShell. Detta f�r att migrationsverktyget ska hitta databasen!
appsettings.json finns i API-projektet och det �r d�r connectionstringen finns.

Enligt f�ljande allts�:
dotnet ef migrations add InitialCreate --project ProjectManagementApp.Infrastructure --startup-project ProjectManagementApp.API

Infrastructure har ingen appsettings.json, s� migration hittar inte databasen
Kanske g�r att fixa genom att ha API som StartUp-Project som standard? 

API:
Har f�ljande filer: 
- appsettings.json
- Program.cs

Infrastructure:

Core: