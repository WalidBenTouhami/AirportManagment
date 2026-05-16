# Airport Management System

A .NET Core application for managing airport operations, including flights, planes, passengers, and staff.

## Architecture

The solution is divided into three main projects following a clean architecture approach:

- **Am.ApplicationCore**: Contains the core domain entities (`Flight`, `Plane`, `Passenger`, `Staff`, `Traveller`) and business logic.
- **AM.Infra**: The Data Access layer using Entity Framework Core. It contains the `AMContext` and database migrations.
- **Am.Ui.Console**: The startup console application used for testing and demonstrating the domain logic.

## Prerequisites

- .NET 10.0 SDK (or compatible version)
- SQL Server LocalDB (comes with Visual Studio) or any SQL Server instance.
- Entity Framework Core CLI (`dotnet-ef`)

## Getting Started

### 1. Database Setup

The project uses EF Core Code-First migrations. To initialize the database, ensure you have the `dotnet-ef` tool installed:
```bash
dotnet tool install --global dotnet-ef
```

Then, apply the latest migrations to create the database:
```bash
dotnet ef database update --project AM.Infra --startup-project Am.Ui.Console
```

### 2. Running the Application

You can run the console application to execute the demonstration scripts:
```bash
dotnet run --project Am.Ui.Console
```

## Adding New Migrations

If you make changes to the domain models in `Am.ApplicationCore`, you can generate a new migration with the following command:
```bash
dotnet ef migrations add <MigrationName> --project AM.Infra --startup-project Am.Ui.Console
```