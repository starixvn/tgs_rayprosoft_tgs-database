using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPromotionPlayerIdToDepositForm : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "promotion_player_id",
            schema: "dbo",
            table: "deposit_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<int>(
            name: "promotion_player_id",
            schema: "dbo",
            table: "deposit_forms",
            type: "integer",
            nullable: true);
    }
}
