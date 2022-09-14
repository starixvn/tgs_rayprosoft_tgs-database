using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPlayerPropertiesTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "player_properties",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "player_properties",
            schema: "dbo",
            columns: table => new
            {
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                value = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_player_properties", x => new { x.brand_id, x.player_code, x.name });
                _ = table.ForeignKey(
                    name: "fk_brand_player_property_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "fk_player_player_property_player_code",
                    column: x => x.player_code,
                    principalSchema: "dbo",
                    principalTable: "players",
                    principalColumn: "player_code",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_properties_player_code",
            schema: "dbo",
            table: "player_properties",
            column: "player_code");
    }
}
