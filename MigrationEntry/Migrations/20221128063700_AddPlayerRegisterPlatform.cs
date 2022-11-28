using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayerRegisterPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_register_platforms",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    created_by_username = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_code", x => x.player_code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_register_platforms",
                schema: "dbo");
        }
    }
}
