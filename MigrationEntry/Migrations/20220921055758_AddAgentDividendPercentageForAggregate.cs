using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAgentDividendPercentageForAggregate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "agent_dividend_percentage",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "agent_dividend_percentage_tree_data",
            schema: "report",
            table: "player_aggregates",
            type: "jsonb",
            nullable: true);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "chief_agent_dividend_percentage",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "actual_dividend_percentage",
            schema: "dbo",
            table: "agent_dividend_multiple_layers",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "agent_covered_bonus",
            schema: "dbo",
            table: "agent_dividend_multiple_layers",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "agent_covered_bonus_adjust",
            schema: "dbo",
            table: "agent_dividend_multiple_layers",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "agent_dividend_percentage",
            schema: "dbo",
            table: "agent_dividend_multiple_layers",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<int>(
            name: "dividend_provider_id",
            schema: "dbo",
            table: "agent_dividend_multiple_layers",
            type: "integer",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "agent_dividend_percentage",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "agent_dividend_percentage_tree_data",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "chief_agent_dividend_percentage",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "actual_dividend_percentage",
            schema: "dbo",
            table: "agent_dividend_multiple_layers");

        _ = migrationBuilder.DropColumn(
            name: "agent_covered_bonus",
            schema: "dbo",
            table: "agent_dividend_multiple_layers");

        _ = migrationBuilder.DropColumn(
            name: "agent_covered_bonus_adjust",
            schema: "dbo",
            table: "agent_dividend_multiple_layers");

        _ = migrationBuilder.DropColumn(
            name: "agent_dividend_percentage",
            schema: "dbo",
            table: "agent_dividend_multiple_layers");

        _ = migrationBuilder.DropColumn(
            name: "dividend_provider_id",
            schema: "dbo",
            table: "agent_dividend_multiple_layers");
    }
}
