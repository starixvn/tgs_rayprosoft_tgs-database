using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayerEventSourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "snapshot_event_id",
                schema: "dbo",
                table: "players",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "player_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_event_source", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_event_source",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "snapshot_event_id",
                schema: "dbo",
                table: "players");
        }
    }
}
