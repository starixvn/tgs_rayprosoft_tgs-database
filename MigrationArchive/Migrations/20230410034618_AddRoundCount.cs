using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;
using Tgs.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddRoundCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "round_count",
                schema: "report",
                table: "round_aggregates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "round_count",
                schema: "report",
                table: "player_game_rebate_aggregates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "round_count",
                schema: "report",
                table: "player_aggregates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            var assembly = Assembly.GetExecutingAssembly();

            migrationBuilder.SqlResource(assembly,
                string.Format(MigrationConsts._FunctionSqlFormat, "report_generate_round_aggregates"));

            migrationBuilder.SqlResource(assembly,
                string.Format(MigrationConsts._FunctionSqlFormat, "report_get_round_and_set_game_setting_aggregates"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "round_count",
                schema: "report",
                table: "round_aggregates");

            migrationBuilder.DropColumn(
                name: "round_count",
                schema: "report",
                table: "player_game_rebate_aggregates");

            migrationBuilder.DropColumn(
                name: "round_count",
                schema: "report",
                table: "player_aggregates");
        }
    }
}
