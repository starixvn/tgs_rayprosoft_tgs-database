using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;
using Tgs.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddInnerExceptionColumnForAdminLog : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.DropColumn(
        "inner_exception",
        schema: "log",
        table: "admin_logs");

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            "inner_exception",
            schema: "log",
            table: "admin_logs",
            type: "text",
            nullable: true);

        var assembly = Assembly.GetExecutingAssembly();

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "log_get_admin_logs"));
    }
}
