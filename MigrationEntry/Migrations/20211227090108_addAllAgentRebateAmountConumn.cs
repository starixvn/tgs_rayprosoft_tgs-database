using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAllAgentRebateAmountConumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "all_agent_rebate_amount",
            schema: "report",
            table: "player_aggregates");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "all_agent_rebate_amount",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
