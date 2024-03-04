using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayerBankInfoEventSourcing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "snapshot_id",
                schema: "dbo",
                table: "player_bank_infos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "player_bank_info_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank_info_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_action = table.Column<string>(type: "text", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    modifier = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bank_info_event_source", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_bank_info_event_source",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "snapshot_id",
                schema: "dbo",
                table: "player_bank_infos");
        }
    }
}
