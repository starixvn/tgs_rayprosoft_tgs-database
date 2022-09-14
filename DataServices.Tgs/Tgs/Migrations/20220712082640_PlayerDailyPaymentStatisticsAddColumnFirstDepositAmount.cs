using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class PlayerDailyPaymentStatisticsAddColumnFirstDepositAmount : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "first_deposit_amount",
            schema: "dbo",
            table: "player_daily_payment_statistics");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "first_deposit_amount",
            schema: "dbo",
            table: "player_daily_payment_statistics",
            type: "numeric",
            nullable: true);
    }
}
