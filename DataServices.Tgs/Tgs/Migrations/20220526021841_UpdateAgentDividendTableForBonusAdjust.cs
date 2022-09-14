using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateAgentDividendTableForBonusAdjust : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "no_include_net_profit_bonus_adjust_amount",
            schema: "dbo",
            table: "agent_dividends");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "no_include_net_profit_bonus_adjust_amount",
            schema: "dbo",
            table: "agent_dividends",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
