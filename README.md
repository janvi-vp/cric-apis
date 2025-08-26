# cric-apis

APIs for managing cricket data, built with .NET and Entity Framework Core.

## Features
- Clean, layered solution: DTOs, Models (EF Core), Repository, Services, and Web API
- SQL Server with EF Core migrations

## Prerequisites
- .NET 9.0 SDK
- SQL Server (LocalDB or SQL Express)
- Visual Studio Code or Visual Studio

## Project structure
- `cric-api.DTOs` – Request/Response DTOs and utilities
- `cric-api.Models` – EF Core entities, DbContext, and migrations
- `cric-api.Repository` – Data access layer
- `cric-api.Services` – Business services
- `cric-apis` – ASP.NET Core Web API (controllers, middleware, config)

## Setup
1) Restore and build the solution

```powershell
dotnet restore .\cric-apis.sln
dotnet build .\cric-apis.sln -c Debug
```

2) Configure the connection string

Edit `cric-apis/appsettings.json` (or `appsettings.Development.json`) and set your SQL Server connection:

```json
{
	"ConnectionStrings": {
		"DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=CricDb;Encrypt=False;Trusted_Connection=True;"
	}
}
```

> Note: You can also use a SQL authentication connection string if preferred.

## Database migrations

Install EF Core tools (if not already installed):

```powershell
dotnet tool install --global dotnet-ef
```

Create a new migration:

```powershell
dotnet ef migrations add <MigrationName> --project .\cric-api.Models\cric-api.Models.csproj --startup-project .\cric-apis\cric-apis.csproj
```

Apply migrations to create/update the database:

```powershell
dotnet ef database update --project .\cric-api.Models\cric-api.Models.csproj --startup-project .\cric-apis\cric-apis.csproj
```

Using Visual Studio Package Manager Console:

Create a new migration:

```powershell
Add-Migration AddPlayerExtras -Project cric-api.Models -StartupProject cric-apis -Context CricContext -OutputDir Migrations
```

Apply migrations to create/update the database:

```powershell
Update-Database -Project cric-api.Models -StartupProject cric-apis -Context CricContext
```

## Run the API

From the API project folder:

```powershell
cd .\cric-apis
dotnet run
```

By default the API listens on the ports configured in `Properties/launchSettings.json` (Development profile). Ensure the `ASPNETCORE_ENVIRONMENT` is set to `Development` for local use.
