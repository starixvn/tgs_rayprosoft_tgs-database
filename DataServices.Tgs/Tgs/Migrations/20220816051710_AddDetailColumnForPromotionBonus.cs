using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddDetailColumnForPromotionBonus : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "detail",
            schema: "dbo",
            table: "promotion_bonuses");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "detail",
            schema: "dbo",
            table: "promotion_bonuses",
            type: "jsonb",
            nullable: true);
    }
}
