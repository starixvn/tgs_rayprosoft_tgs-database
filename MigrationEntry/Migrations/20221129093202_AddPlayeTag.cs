using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayeTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_register_platforms",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "player_tags",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    tag = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_player_code_tag", x => new { x.player_code, x.tag });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_tags",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "player_register_platforms",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_by_username = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_register_platform_player_code", x => x.player_code);
                });
        }
    }
}
