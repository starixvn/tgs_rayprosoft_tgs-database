using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_GameBet_Indexes_ClosedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_closed_on_bet_state",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_closed_on_id",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_player_code_composite",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_updated_on",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_updated_on");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_player_code",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_player_code");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_game_provider_id",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_game_provider_id");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_game_id",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_game_id");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_external_created_on",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_external_created_on");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_external_closed_on",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_external_closed_on");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_closed_on_brand_id",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on",
                schema: "dbo",
                table: "game_bet_closes",
                column: "closed_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_currency_code",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "currency_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_external_bet_id",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "external_bet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_external_round_id",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "external_round_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_closed_on",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_currency_code",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_external_bet_id",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_bet_closes_external_round_id",
                schema: "dbo",
                table: "game_bet_closes");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_updated_on",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_updated_on");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_player_code",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_player_code");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_game_provider_id",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_game_provider_id");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_game_id",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_game_id");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_external_created_on",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_external_created_on");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_external_closed_on",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_external_closed_on");

            migrationBuilder.RenameIndex(
                name: "ix_game_bet_closes_brand_id",
                schema: "dbo",
                table: "game_bet_closes",
                newName: "ix_game_bet_closes_closed_on_brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_bet_state",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "bet_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_id",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_player_code_composite",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "game_provider_id", "game_id", "player_code", "external_bet_id" });
        }
    }
}
