using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddFilterForGetApiLogs : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder) =>
        migrationBuilder.AddColumn<bool>(
            "rebate",
            schema: "bet",
            table: "rounds",
            type: "boolean",
            nullable: true);

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            "rebate",
            schema: "bet",
            table: "rounds");

        var assembly = Assembly.GetExecutingAssembly();

        migrationBuilder.SqlResource(assembly,
            string.Format(Consts._FunctionSqlFormat, "report_generate_round_aggregates"));
        migrationBuilder.SqlResource(assembly,
            string.Format(Consts._FunctionSqlFormat, "report_get_round_and_set_game_setting_aggregates"));
        migrationBuilder.SqlResource(assembly,
            string.Format(Consts._FunctionSqlFormat, "log_get_api_logs"));
    }
}
