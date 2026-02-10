# ASPNETCoreWebAPI_UseCaseAPI

A simple HelpDesk Ticketing API built with ASP.NET Core Web API using CQRS / Use-case approach. This API allows creating, assigning, closing, reopening, escalating, commenting, and changing the priority of tickets.

Add migrations and update the database:

add-migrations InitialCreate
update-database update

Running the Application: dotnet run

The API will be available at:

http://localhost:8000

https://localhost:9000

Swagger UI is enabled in Development:

http://localhost:8000/swagger

Data Transfer Objects (DTOs) : TicketDto, CreateTicketDto, CommentDto, ChangePriorityDto