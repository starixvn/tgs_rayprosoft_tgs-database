using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddGameLocaliztion : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "localization",
            schema: "dbo",
            table: "games");

        _ = migrationBuilder.DropColumn(
            name: "localization",
            schema: "dbo",
            table: "game_providers");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "localization",
            schema: "dbo",
            table: "games",
            type: "jsonb",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "localization",
            schema: "dbo",
            table: "game_providers",
            type: "jsonb",
            nullable: true);
    }
}
