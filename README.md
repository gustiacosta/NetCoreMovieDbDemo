# NetCoreMovieDb Demo App

# DB Setup
- Run create-db.sql and create-tables-and-records.sql (for SQL Server Express). This will also create all sample records

# DotNetCoolMovies.ApiService project
- dotnet run (runs on port 5001) 

# DotNetCoolMovies.ReactUI project
- dotnet run (runs on port 5002) 

Additionaly can check Helthcheck ui page on
https://localhost:5001/healthchecks-ui


# Stack 
# Backend
* Clean Arquitecture
* .Net Core (5.0)
* Generic Repository Pattern
* Entity Framework Core
* Linq
* Automapper
* ILogger (Nlog)
* HttpClient factory
* Http Retry-Policy (Polly extension)
* SQL Server Express
* Swagger
* Fluent validations
* Health checks UI
* Unit testing with xUnit

# Frontend
* React
* Bootstrap
