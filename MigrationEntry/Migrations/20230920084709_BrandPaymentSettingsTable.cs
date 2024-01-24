using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class BrandPaymentSettingsTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "brand_payment_settings",
            schema: "dbo",
            columns: table => new
            {
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                player_bank_info_count_limit = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_brand_payment_settings", x => x.brand_id);
                table.ForeignKey(
                    name: "fk_brands",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "fk_brands",
            schema: "dbo",
            table: "brand_bucket_types");

        migrationBuilder.DropTable(
            name: "brand_payment_settings",
            schema: "dbo");
    }
}
