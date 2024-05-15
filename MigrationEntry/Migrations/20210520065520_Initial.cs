using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Initial : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.EnsureSchema(
            name: "log");

        _ = migrationBuilder.EnsureSchema(
            name: "dbo");

        _ = migrationBuilder.EnsureSchema(
            name: "bet");

        _ = migrationBuilder.EnsureSchema(
            name: "report");

        _ = migrationBuilder.AlterDatabase()
            .Annotation("Npgsql:PostgresExtension:ltree", ",,")
            .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,");

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("Tgs.Migrations.SqlScripts.tgs_init.sql");
        using var reader = new StreamReader(stream!);

        var sql = reader.ReadToEnd();
        _ = migrationBuilder.Sql(sql);
    }
}