using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RemoveBrandPaymentNonUseColumns : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "fee_percentage",
            schema: "dbo",
            table: "brand_payments",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "highest_fee",
            schema: "dbo",
            table: "brand_payments",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "lowest_fee",
            schema: "dbo",
            table: "brand_payments",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "fee_percentage",
            schema: "dbo",
            table: "brand_payments");

        _ = migrationBuilder.DropColumn(
            name: "highest_fee",
            schema: "dbo",
            table: "brand_payments");

        _ = migrationBuilder.DropColumn(
            name: "lowest_fee",
            schema: "dbo",
            table: "brand_payments");
    }
}
