using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagerPrimary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_wager_primaries",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_wager_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注識別碼"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方下注/創建時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_primaries", x => new { x.external_created_on, x.game_provider_id, x.game_id, x.wallet_id, x.external_wager_id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "game_provider_id", "game_id", "wallet_id", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on",
                schema: "dbo",
                table: "game_wager_primaries",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_brand_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "brand_id" });

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
                name: "ix_game_wager_primaries_e_c_on_c_on_external_round_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_external_wager_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "external_wager_id" });

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

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_external_round_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_external_wager_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_game_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_licensee_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_player_code",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_reseller_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "reseller_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_primaries",
                schema: "dbo");
        }
    }
}
