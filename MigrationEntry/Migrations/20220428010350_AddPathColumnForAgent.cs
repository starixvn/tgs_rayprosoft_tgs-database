using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPathColumnForAgent : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ix_agents_gist_path",
            schema: "dbo",
            table: "agents");

        _ = migrationBuilder.DropColumn(
            name: "path",
            schema: "dbo",
            table: "agents");

        _ = migrationBuilder.AlterDatabase()
            .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,")
            .OldAnnotation("Npgsql:PostgresExtension:ltree", ",,")
            .OldAnnotation("Npgsql:PostgresExtension:pg_trgm", ",,");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterDatabase()
            .Annotation("Npgsql:PostgresExtension:ltree", ",,")
            .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,")
            .OldAnnotation("Npgsql:PostgresExtension:pg_trgm", ",,");

        _ = migrationBuilder.AddColumn<string>(
            name: "path",
            schema: "dbo",
            table: "agents",
            type: "ltree",
            nullable: false,
            defaultValue: "");

        _ = migrationBuilder.CreateIndex(
            name: "ix_agents_gist_path",
            schema: "dbo",
            table: "agents",
            column: "path")
            .Annotation("Npgsql:IndexMethod", "gist");

        var assembly = Assembly.GetExecutingAssembly();

        migrationBuilder.SqlResource(assembly,
            string.Format(Consts._FunctionSqlFormat, "agent_update_path"));

        migrationBuilder.SqlResource(assembly,
            string.Format(Consts._FunctionSqlFormat, "agent_get_all_sub_agents"));
    }
}
