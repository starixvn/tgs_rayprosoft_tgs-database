using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Drop_Table_Game_Wager_Game_Bet_Event_Sources_Game_Bet_Marker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_bet_event_sources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_bet_markers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_firsts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wagers",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_bet_event_sources",
                schema: "dbo",
                columns: table => new
                {
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "附加數據"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    bet_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單狀態"),
                    bet_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單類型"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_bet_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注單別碼"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    jackpot = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "彩金"),
                    jackpot_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "彩金狀態"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_bet_event_sources", x => new { x.created_on, x.id });
                });

            migrationBuilder.CreateTable(
                name: "game_bet_markers",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "代碼"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    directions = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "說明"),
                    expansions = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "擴充"),
                    marker = table.Column<Guid>(type: "uuid", nullable: false, comment: "標記"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_bet_markers", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "game_wager_details",
                schema: "dbo",
                columns: table => new
                {
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    wager_id = table.Column<long>(type: "bigint", nullable: false, comment: "投注識別碼"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "附加數據"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_details", x => new { x.created_on, x.wager_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_firsts",
                schema: "dbo",
                columns: table => new
                {
                    first_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "首筆時間"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_wager_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注識別碼"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    cancel_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "取消狀態"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "結束時間"),
                    closed_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "關閉狀態"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    void_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "作廢狀態"),
                    wager_id = table.Column<long>(type: "bigint", nullable: false, comment: "投注識別碼"),
                    wager_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注狀態"),
                    wager_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注類型"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_firsts", x => new { x.first_on, x.game_provider_id, x.game_id, x.wallet_id, x.external_wager_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wagers",
                schema: "dbo",
                columns: table => new
                {
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_wager_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注識別碼"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    cancel_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "取消狀態"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "結束時間"),
                    closed_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "關閉狀態"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    reset_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "重置時間"),
                    reset_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重置狀態"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    void_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "作廢狀態"),
                    wager_id = table.Column<long>(type: "bigint", nullable: false, comment: "投注識別碼"),
                    wager_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注狀態"),
                    wager_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注類型"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wagers", x => new { x.created_on, x.game_provider_id, x.game_id, x.wallet_id, x.external_wager_id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "game_provider_id", "game_id", "wallet_id", "external_bet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_brand_id",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_brand_id_bet_state",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "brand_id", "bet_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_brand_id_bet_state_id",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "brand_id", "bet_state", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_brand_id_id",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "brand_id", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_g_p",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_g_p_bet_state",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "game_provider_id", "bet_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_g_p_bet_state_id",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "game_provider_id", "bet_state", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_event_sources_g_p_id",
                schema: "dbo",
                table: "game_bet_event_sources",
                columns: new[] { "created_on", "game_provider_id", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_details_wager_id",
                schema: "dbo",
                table: "game_wager_details",
                column: "wager_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "game_provider_id", "game_id", "wallet_id", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_external_round_id",
                schema: "dbo",
                table: "game_wager_firsts",
                column: "external_round_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_external_wager_id",
                schema: "dbo",
                table: "game_wager_firsts",
                column: "external_wager_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_brand_id",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_brand_id_player_code",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "brand_id", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_external_round_id",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_external_wager_id",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_game_id",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_player_code",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_first_on_wager_id",
                schema: "dbo",
                table: "game_wager_firsts",
                columns: new[] { "first_on", "wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_firsts_wager_id",
                schema: "dbo",
                table: "game_wager_firsts",
                column: "wager_id");

            migrationBuilder.CreateIndex(
                name: "ix_created_on_brand_id",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_created_on_brand_id_player_code",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "brand_id", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_created_on_external_round_id",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_created_on_external_wager_id",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_created_on_game_id",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_created_on_game_provider_id",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_created_on_player_code",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_created_on_wager_id",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "created_on", "wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_external_round_id",
                schema: "dbo",
                table: "game_wagers",
                column: "external_round_id");

            migrationBuilder.CreateIndex(
                name: "ix_external_wager_id",
                schema: "dbo",
                table: "game_wagers",
                column: "external_wager_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wagers",
                schema: "dbo",
                table: "game_wagers",
                columns: new[] { "game_provider_id", "game_id", "wallet_id", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_wager_id",
                schema: "dbo",
                table: "game_wagers",
                column: "wager_id");
        }
    }
}
