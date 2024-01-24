using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Edit_Table_BrandGameCreditProfit_Index_ix_brand_game_credit_profits_brand_id : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "ix_brand_game_credit_brand_id",
            schema: "dbo",
            table: "brand_game_credit_profits");

        migrationBuilder.AddPrimaryKey(
            name: "pk_brand_game_credit_profits",
            schema: "dbo",
            table: "brand_game_credit_profits",
            columns: new[] { "brand_id", "month", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_brand_game_credit_profits_brand_id",
            schema: "dbo",
            table: "brand_game_credit_profits",
            columns: new[] { "brand_id", "month" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "pk_brand_game_credit_profits",
            schema: "dbo",
            table: "brand_game_credit_profits");

        migrationBuilder.DropIndex(
            name: "ix_brand_game_credit_profits_brand_id",
            schema: "dbo",
            table: "brand_game_credit_profits");

        migrationBuilder.AddPrimaryKey(
            name: "ix_brand_game_credit_brand_id",
            schema: "dbo",
            table: "brand_game_credit_profits",
            columns: new[] { "brand_id", "month" });
    }
}
