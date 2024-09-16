using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_GameBetMajor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_bet_majors",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_bet_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注單別碼"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true, comment: "玩家代碼"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true, comment: "貨幣代碼"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "三方局/回合識別碼"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    bet_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單狀態"),
                    bet_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單類型"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    jackpot_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "彩金狀態"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "貨幣比例"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "結算(包含本金)"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "玩家損益/淨利"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "傭金"),
                    contribute = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "貢獻/彩金貢獻"),
                    jackpot = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "彩金"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "結束時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: true, defaultValueSql: "'{}'::jsonb", comment: "附加數據"),
                    extended_data = table.Column<string>(type: "jsonb", nullable: true, defaultValueSql: "'{}'::jsonb", comment: "擴充數據")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_bet_majors", x => new { x.external_created_on, x.game_provider_id, x.game_id, x.wallet_id, x.external_bet_id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on",
                schema: "dbo",
                table: "game_bet_majors",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_brand_id",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_closed_on",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_created_on",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_currency_code",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "currency_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_external_bet_id",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "external_bet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_external_closed_on",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_external_payoff_on",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_external_resettle_on",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "external_resettle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_external_round_id",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_game_id",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_game_provider_id",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_id",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_player_code",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_updated_on",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "updated_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bet_majors_external_created_on_wallet_id",
                schema: "dbo",
                table: "game_bet_majors",
                columns: new[] { "external_created_on", "wallet_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_bet_majors",
                schema: "dbo");
        }
    }
}
