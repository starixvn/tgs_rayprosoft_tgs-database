using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AlterVipSettingsAddWithdrawLimit : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<decimal>(
            name: "withdraw_total_amount_per_day",
            schema: "dbo",
            table: "vip_levels",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValueSql: "-1");

        migrationBuilder.AddColumn<int>(
            name: "withdraw_transactions_per_day",
            schema: "dbo",
            table: "vip_levels",
            type: "integer",
            nullable: false,
            defaultValueSql: "-1");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "withdraw_total_amount_per_day",
            schema: "dbo",
            table: "vip_levels");

        migrationBuilder.DropColumn(
            name: "withdraw_transactions_per_day",
            schema: "dbo",
            table: "vip_levels");
    }
}
