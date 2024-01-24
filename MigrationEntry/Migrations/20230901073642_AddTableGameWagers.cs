using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddTableGameWagers : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "game_wagers",
            schema: "dbo",
            columns: table => new
            {
                game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                external_wager_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注識別碼"),
                created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                wager_id = table.Column<long>(type: "bigint", nullable: false, comment: "投注識別碼"),
                game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                wager_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注狀態"),
                wager_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "投注類型"),
                closed_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "關閉狀態"),
                void_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "作廢狀態"),
                cancel_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "取消狀態"),
                free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "結束時間"),
                updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                reset_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重置狀態"),
                reset_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "重置時間")
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_game_wagers", x => new { x.created_on, x.game_provider_id, x.game_id, x.wallet_id, x.external_wager_id });
            });

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
            name: "ix_id",
            schema: "dbo",
            table: "game_wagers",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "ix_wager_id",
            schema: "dbo",
            table: "game_wagers",
            column: "wager_id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "game_wagers",
            schema: "dbo");
    }
}
