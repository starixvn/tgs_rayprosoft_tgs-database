using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagerPrimaryDetail_Index_CreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primary_details",
                schema: "dbo",
                table: "game_wager_primary_details");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "game_wager_primary_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "game_wager_primary_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primary_details_c_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_primary_details",
                columns: new[] { "created_on", "game_wager_primary_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_c_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primary_details_c_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_primary_details");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements",
                column: "game_wager_primary_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                column: "game_wager_primary_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primary_details",
                schema: "dbo",
                table: "game_wager_primary_details",
                column: "game_wager_primary_id");
        }
    }
}
