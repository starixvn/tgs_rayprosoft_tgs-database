using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPlayerParentsTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "player_parents",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "player_parents",
            schema: "dbo",
            columns: table => new
            {
                player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                parent_player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_player_parent_code", x => x.player_code);
            });

        _ = migrationBuilder.CreateIndex("ix_parent_player_code", "player_parents", "parent_player_code", "dbo");
    }
}
