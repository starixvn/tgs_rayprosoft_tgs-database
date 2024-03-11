using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagerPrimary_Alter_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on_brand_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on_game_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on_licensee_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on_player_code",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_c_on_reseller_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_brand_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_game_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_licensee_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_player_code",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_reseller_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "reseller_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_brand_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_game_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_licensee_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_player_code",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_reseller_id",
                schema: "dbo",
                table: "game_wager_primaries");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on",
                schema: "dbo",
                table: "game_wager_primaries",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on_brand_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on_game_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on_licensee_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "created_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on_player_code",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_c_on_reseller_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "created_on", "reseller_id" });
        }
    }
}
