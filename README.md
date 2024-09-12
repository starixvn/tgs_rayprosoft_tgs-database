# tgs-database

In real world projects, data models change as features get implemented: new entities or properties are added and removed, and database schemas need to be changed accordingly to be kept in sync with the application. The migrations feature in EF Core provides a way to incrementally update the database schema to keep it in sync with the application's data model while preserving existing data in the database.

At a high level, migrations function in the following way:

When a data model change is introduced, the developer uses EF Core tools to add a corresponding migration describing the updates necessary to keep the database schema in sync. EF Core compares the current model against a snapshot of the old model to determine the differences, and generates migration source files; the files can be tracked in your project's source control like any other source file.
Once a new migration has been generated, it can be applied to a database in various ways. EF Core records all applied migrations in a special history table, allowing it to know which migrations have been applied and which haven't.
The rest of this page is a step-by-step beginner's guide for using migrations. Consult the other pages in this section for more in-depth information.

## Create your database and schema

**1.~\tgs-database\MigrationEntry**
```sh
dotnet ef database update
```

**2.User tgs-database/TgsSeeding**
```sh
dotnet run --project .\TgsSeeding\TgsSeeding.csproj --framework net8.0
```

## - Migrations

**migrations add/alter/delete/drop**
```sh
dotnet ef migrations add {name}
```