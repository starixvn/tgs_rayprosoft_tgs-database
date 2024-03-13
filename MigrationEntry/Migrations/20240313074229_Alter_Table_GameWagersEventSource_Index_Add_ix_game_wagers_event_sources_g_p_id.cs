using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagersEventSource_Index_Add_ix_game_wagers_event_sources_g_p_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_game_wagers_event_sources_g_p_id",
                schema: "dbo",
                table: "game_wagers_event_sources",
                columns: new[] { "created_on", "game_provider_id", "id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wagers_event_sources_g_p_id",
                schema: "dbo",
                table: "game_wagers_event_sources");
        }
    }
}
