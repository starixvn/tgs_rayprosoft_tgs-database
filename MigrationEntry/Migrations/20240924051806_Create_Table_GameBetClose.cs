using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_GameBetClose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_bet_closes",
                schema: "dbo",
                columns: table => new
                {
                    game_bet_major_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
                    closed_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "結束時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, defaultValueSql: "''::character varying", comment: "玩家代碼"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, defaultValueSql: "''::character varying", comment: "貨幣代碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "''::character varying", comment: "三方局/回合識別碼"),
                    external_bet_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, defaultValueSql: "''::character varying", comment: "三方投注單別碼"),
                    external_created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "三方下注/創建時間"),
                    external_closed_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "三方結算/結束時間"),
                    external_payoff_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "三方重新結算時間"),
                    bet_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單狀態"),
                    bet_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單類型"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    jackpot_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "彩金狀態"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "流水(依照遊戲商提供流水,如遊戲商未提供預設有效下注)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    contribute = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貢獻/彩金貢獻"),
                    jackpot = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "彩金"),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "創建時間"),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "修改時間"),
                    reset_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重置狀態"),
                    reset_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "重置時間"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "附加數據"),
                    extended_data = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "擴充數據")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_bet_closes", x => new { x.closed_on, x.game_bet_major_id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_brand_id",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_external_closed_on",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_external_created_on",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "external_created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_game_id",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_game_provider_id",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_game_provider_id_game_id_wallet_i",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "game_provider_id", "game_id", "wallet_id", "external_bet_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_id",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_player_code",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_closes_closed_on_updated_on",
                schema: "dbo",
                table: "game_bet_closes",
                columns: new[] { "closed_on", "updated_on" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_bet_closes",
                schema: "dbo");
        }
    }
}
