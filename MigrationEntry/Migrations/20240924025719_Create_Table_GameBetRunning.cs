using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_GameBetRunning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_bet_runnings",
                schema: "dbo",
                columns: table => new
                {
                    game_bet_major_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true, comment: "玩家代碼"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true, comment: "貨幣代碼"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "三方局/回合識別碼"),
                    external_bet_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "三方投注單別碼"),
                    external_created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "三方下注/創建時間"),
                    bet_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單類型"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "貨幣比例"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "實際/有效下注"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "創建時間"),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "修改時間"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: true, defaultValueSql: "'{}'::jsonb", comment: "附加數據"),
                    extended_data = table.Column<string>(type: "jsonb", nullable: true, defaultValueSql: "'{}'::jsonb", comment: "擴充數據")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_bet_runnings", x => x.game_bet_major_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_runnings_game_provider_id_game_id_wallet_id_extern",
                schema: "dbo",
                table: "game_bet_runnings",
                columns: new[] { "game_provider_id", "game_id", "wallet_id", "external_bet_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_bet_runnings",
                schema: "dbo");
        }
    }
}
