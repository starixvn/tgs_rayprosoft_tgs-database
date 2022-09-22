using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAnnouncementType : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "fk_agent_bank_infos_players_player_temp_id",
            schema: "dbo",
            table: "agent_bank_infos");

        _ = migrationBuilder.DropColumn(
            name: "type",
            schema: "dbo",
            table: "announcements");

        _ = migrationBuilder.AddForeignKey(
            name: "fk_agent_bank_infos_players_player_code",
            schema: "dbo",
            table: "agent_bank_infos",
            column: "player_code",
            principalSchema: "dbo",
            principalTable: "players",
            principalColumn: "player_code");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "fk_agent_bank_infos_players_player_code",
            schema: "dbo",
            table: "agent_bank_infos");

        _ = migrationBuilder.AddColumn<string>(
            name: "type",
            schema: "dbo",
            table: "announcements",
            type: "text",
            nullable: false,
            defaultValue: "Marquee");

        _ = migrationBuilder.AddForeignKey(
            name: "fk_agent_bank_infos_players_player_temp_id",
            schema: "dbo",
            table: "agent_bank_infos",
            column: "player_code",
            principalSchema: "dbo",
            principalTable: "players",
            principalColumn: "player_code");
    }
}
