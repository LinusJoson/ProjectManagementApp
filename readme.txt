
This version is currently(as of 2025-02-23) in development and is not yet ready for final release/use.

The current version is a simple project management application that is intended to allow users to create, read, update and delete projects and customers.
This is intended to be handled in a database and the current version uses Entity Framework Core to interact with a LocalDB database.

The current version has an API that allows users to interact with the database and is intended to be used by a front-end application created in React/Vite.
The Front-end application is not yet created.

What is included in the current version:

* Api (Presentation)
- WebApi
- Controllers/ that receive http requests and handle API logic. (ProjectController.cs + CustomerController.cs)
- appsettings.json (configuration file)
- Program.cs (starts the application)
- ProjectManagementApp.API.http (test file to test the API)

* Core (Domain layer)
- Entities/ that contain domain models (Project.cs + Customer.cs + ProjectManager.cs + ServiceType.cs)
- Interfaces/ that contain interfaces (ICustomerService.cs + IProjectService.cs)

* Infrastructure (Data Access Layer)
- Services/ that contain services to handle data (CustomerService.cs + ProjectService.cs)
- Repositories/ that contain repositories to handle data (CustomerRepository.cs + ProjectRepository.cs)

---
What is planned for the upcoming version:

* Front-end application (React/Vite)
- Create a front-end application that allows users to interact with the database and display the data in a user-friendly way.