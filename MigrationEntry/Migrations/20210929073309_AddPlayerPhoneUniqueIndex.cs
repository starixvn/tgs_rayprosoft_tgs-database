using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPlayerPhoneUniqueIndex : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ux_players_brand_phone",
            schema: "dbo",
            table: "players");

        _ = migrationBuilder.CreateIndex(
            name: "ix_players_brand_id",
            schema: "dbo",
            table: "players",
            column: "brand_id");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ix_players_brand_id",
            schema: "dbo",
            table: "players");

        _ = migrationBuilder.CreateIndex(
            name: "ux_players_brand_phone",
            schema: "dbo",
            table: "players",
            columns: new[] { "brand_id", "area_code", "phone" },
            unique: true);
    }
}
