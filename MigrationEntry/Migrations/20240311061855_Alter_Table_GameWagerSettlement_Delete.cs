using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagerSettlement_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_settlement_firsts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_settlements",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_wager_settlement_firsts",
                schema: "dbo",
                columns: table => new
                {
                    first_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "首筆時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "結束時間"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "創建時間"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方結算/結束時間"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "三方重新結算時間"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    game_wager_primary_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
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
                    table.PrimaryKey("pk_game_wager_settlement_firsts", x => new { x.first_on, x.id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_settlements",
                schema: "dbo",
                columns: table => new
                {
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "結束時間"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    game_wager_primary_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
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
                    table.PrimaryKey("pk_game_wager_settlements", x => new { x.created_on, x.id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                column: "game_wager_primary_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                column: "first_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_resettle_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_resettle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "updated_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "wager_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements",
                column: "game_wager_primary_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on",
                schema: "dbo",
                table: "game_wager_settlements",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_external_created_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "external_created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "wager_state" });
        }
    }
}
