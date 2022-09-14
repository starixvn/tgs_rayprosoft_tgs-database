using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateBrandPaymentDepositWithdrawForm : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "handling_fee",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "handling_fee",
            schema: "dbo",
            table: "deposit_forms");

        _ = migrationBuilder.DropColumn(
            name: "handling_fee_rate_ten_percentile",
            schema: "dbo",
            table: "brand_payments");

        _ = migrationBuilder.DropColumn(
            name: "reduce_player_amount",
            schema: "dbo",
            table: "brand_payments");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "handling_fee",
            schema: "dbo",
            table: "withdraw_forms",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "handling_fee",
            schema: "dbo",
            table: "deposit_forms",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "handling_fee_rate_ten_percentile",
            schema: "dbo",
            table: "brand_payments",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<bool>(
            name: "reduce_player_amount",
            schema: "dbo",
            table: "brand_payments",
            type: "boolean",
            nullable: false,
            defaultValue: false);
    }
}
