using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddOriginalTurnoverColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "original_turnover",
            schema: "report",
            table: "round_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "bet_amount",
            schema: "report",
            table: "player_game_rebate_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "original_turnover",
            schema: "report",
            table: "player_game_rebate_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "valid_bet_amount",
            schema: "report",
            table: "player_game_rebate_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "original_turnover",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "valid_bet_amount",
            schema: "report",
            table: "player_aggregates");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "original_turnover",
            schema: "report",
            table: "round_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "bet_amount",
            schema: "report",
            table: "player_game_rebate_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "original_turnover",
            schema: "report",
            table: "player_game_rebate_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "valid_bet_amount",
            schema: "report",
            table: "player_game_rebate_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "original_turnover",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "valid_bet_amount",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        var assembly = Assembly.GetExecutingAssembly();

        migrationBuilder.SqlResource(assembly,
            string.Format(Consts._FunctionSqlFormat, "report_generate_round_aggregates"));
    }
}
