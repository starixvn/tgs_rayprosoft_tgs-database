using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_GameBet_Indexes_Composite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "ix_game_bet_runnings_game_provider_id_game_id_wallet_id_extern",
                schema: "dbo",
                table: "game_bet_runnings",
                newName: "ux_game_bet_runnings");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_game_provider_id_game_id_wallet_i",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ux_game_bet_closes");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_runnings_brand_id",
                schema: "dbo",
                table: "game_bet_runnings",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_runnings_game_id",
                schema: "dbo",
                table: "game_bet_runnings",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_runnings_game_provider_id",
                schema: "dbo",
                table: "game_bet_runnings",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_runnings_player_code",
                schema: "dbo",
                table: "game_bet_runnings",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_runnings_player_code_composite",
                schema: "dbo",
                table: "game_bet_runnings",
                columns: new[] { "game_provider_id", "game_id", "player_code", "external_bet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_bet_state",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "bet_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_player_code_composite",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "game_provider_id", "game_id", "player_code", "external_bet_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_bet_runnings_brand_id",
                schema: "dbo",
                table: "game_bet_runnings");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_runnings_game_id",
                schema: "dbo",
                table: "game_bet_runnings");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_runnings_game_provider_id",
                schema: "dbo",
                table: "game_bet_runnings");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_runnings_player_code",
                schema: "dbo",
                table: "game_bet_runnings");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_runnings_player_code_composite",
                schema: "dbo",
                table: "game_bet_runnings");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_closed_on_bet_state",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_player_code_composite",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.RenameIndex(
                name: "ux_game_bet_runnings",
                schema: "dbo",
                table: "game_bet_runnings",
                newName: "ix_game_bet_runnings_game_provider_id_game_id_wallet_id_extern");

            migrationBuilder.RenameIndex(
                name: "ux_game_bet_closes",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_game_provider_id_game_id_wallet_i");
        }
    }
}
