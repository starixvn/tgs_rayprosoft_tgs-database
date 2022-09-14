using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateAgentDividendAndPlayerAggregateTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "deposit_handling_fee",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "withdraw_handling_fee",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "deposit_handling_fee",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.DropColumn(
            name: "withdraw_handling_fee",
            schema: "dbo",
            table: "agent_dividends");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "deposit_handling_fee",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "withdraw_handling_fee",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "deposit_handling_fee",
            schema: "dbo",
            table: "agent_dividends",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "withdraw_handling_fee",
            schema: "dbo",
            table: "agent_dividends",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
