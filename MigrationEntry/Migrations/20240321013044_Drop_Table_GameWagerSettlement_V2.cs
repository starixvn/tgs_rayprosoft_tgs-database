using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Drop_Table_GameWagerSettlement_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_primary_details",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_settlement_firsts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_settlements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wagers_event_sources",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_wager_primary_details",
                schema: "dbo",
                columns: table => new
                {
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方下注/創建時間"),
                    game_wager_primary_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "附加數據"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_primary_details", x => new { x.external_created_on, x.game_wager_primary_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_settlement_firsts",
                schema: "dbo",
                columns: table => new
                {
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    game_wager_primary_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "結束時間"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "創建時間"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方結算/結束時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方重新結算時間"),
                    first_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "首筆時間"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    wager_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注狀態"),
                    wager_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注類型"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_settlement_firsts", x => new { x.external_created_on, x.game_wager_primary_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_settlements",
                schema: "dbo",
                columns: table => new
                {
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    game_wager_primary_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "結束時間"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    reset_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "重置時間"),
                    reset_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重置狀態"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    wager_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注狀態"),
                    wager_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注類型"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_settlements", x => new { x.external_created_on, x.game_wager_primary_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wagers_event_sources",
                schema: "dbo",
                columns: table => new
                {
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "附加數據"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    external_wager_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注識別碼"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    wager_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注狀態"),
                    wager_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注類型"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wagers_event_sources", x => new { x.created_on, x.id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primary_details_e_c_on_id",
                schema: "dbo",
                table: "game_wager_primary_details",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_e_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_e_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_e_resettle_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_resettle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_id",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "updated_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "wager_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on",
                schema: "dbo",
                table: "game_wager_settlements",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_e_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_e_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_e_resettle_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_resettle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_id",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "updated_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "wager_state" });

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
                name: "ix_game_wagers_event_sources_g_p_id",
                schema: "dbo",
                table: "game_wagers_event_sources",
                columns: new[] { "created_on", "game_provider_id", "id" });

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
    }
}
