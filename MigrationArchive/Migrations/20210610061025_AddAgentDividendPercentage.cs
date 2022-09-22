using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAgentDividendPercentage : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "agent_dividend_percentage",
            schema: "report",
            table: "player_aggregates");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "agent_dividend_percentage",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(9,6)",
            precision: 9,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
