using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagersEventSource_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wagers_event_sources",
                schema: "dbo",
                table: "game_wagers_event_sources");

            migrationBuilder.CreateIndex(
                name: "ix_game_wagers_event_sources",
                schema: "dbo",
                table: "game_wagers_event_sources",
                columns: new[] { "created_on", "game_provider_id", "game_id", "wallet_id", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wagers_event_sources_g_p",
                schema: "dbo",
                table: "game_wagers_event_sources",
                columns: new[] { "created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wagers_event_sources_g_p_wager_state",
                schema: "dbo",
                table: "game_wagers_event_sources",
                columns: new[] { "created_on", "game_provider_id", "wager_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wagers_event_sources_g_p_wager_state_id",
                schema: "dbo",
                table: "game_wagers_event_sources",
                columns: new[] { "created_on", "game_provider_id", "wager_state", "id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wagers_event_sources",
                schema: "dbo",
                table: "game_wagers_event_sources");

            migrationBuilder.DropIndex(
                name: "ix_game_wagers_event_sources_g_p",
                schema: "dbo",
                table: "game_wagers_event_sources");

            migrationBuilder.DropIndex(
                name: "ix_game_wagers_event_sources_g_p_wager_state",
                schema: "dbo",
                table: "game_wagers_event_sources");

            migrationBuilder.DropIndex(
                name: "ix_game_wagers_event_sources_g_p_wager_state_id",
                schema: "dbo",
                table: "game_wagers_event_sources");

            migrationBuilder.CreateIndex(
                name: "ix_game_wagers_event_sources",
                schema: "dbo",
                table: "game_wagers_event_sources",
                columns: new[] { "game_provider_id", "game_id", "wallet_id", "external_wager_id" });
        }
    }
}
