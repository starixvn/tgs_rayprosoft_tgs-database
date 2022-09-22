using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AgentDailyPaymentStatisticsAddColumnDepositPlayers : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "deposit_players",
            schema: "dbo",
            table: "agent_daily_payment_statistics");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<int>(
            name: "deposit_players",
            schema: "dbo",
            table: "agent_daily_payment_statistics",
            type: "integer",
            nullable: false,
            defaultValue: 0);
    }
}
