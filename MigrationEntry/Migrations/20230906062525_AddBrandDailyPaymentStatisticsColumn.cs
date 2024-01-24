using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBrandDailyPaymentStatisticsColumn : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "daily_deposit_approved_count",
            schema: "dbo",
            table: "brand_daily_payment_statistics",
            type: "integer",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "daily_deposit_reject_count",
            schema: "dbo",
            table: "brand_daily_payment_statistics",
            type: "integer",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "daily_deposit_total_count",
            schema: "dbo",
            table: "brand_daily_payment_statistics",
            type: "integer",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "daily_deposit_approved_count",
            schema: "dbo",
            table: "brand_daily_payment_statistics");

        migrationBuilder.DropColumn(
            name: "daily_deposit_reject_count",
            schema: "dbo",
            table: "brand_daily_payment_statistics");

        migrationBuilder.DropColumn(
            name: "daily_deposit_total_count",
            schema: "dbo",
            table: "brand_daily_payment_statistics");
    }
}
