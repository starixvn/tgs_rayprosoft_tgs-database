using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddDepositPromotionCalculatePairTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "deposit_promotion_calculate_pairs",
            schema: "dbo",
            columns: table => new
            {
                promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                calculate_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_deposit_promotion_calculate_pairs", x => x.promotion_id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "deposit_promotion_calculate_pairs",
            schema: "dbo");
    }
}
