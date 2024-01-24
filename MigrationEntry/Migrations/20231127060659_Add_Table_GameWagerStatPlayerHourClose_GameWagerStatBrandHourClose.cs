using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Add_Table_GameWagerStatPlayerHourClose_GameWagerStatBrandHourClose : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "game_wager_stat_brand_hour_closes",
            schema: "dbo",
            columns: table => new
            {
                reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                stat_day_on = table.Column<DateOnly>(type: "date", nullable: false, comment: "統計日期時間"),
                count = table.Column<int>(type: "integer", precision: 18, scale: 6, nullable: false, defaultValue: 0, comment: "筆數"),
                bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_game_wager_stat_brand_hour_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.game_provider_id });
            });

        migrationBuilder.CreateTable(
            name: "game_wager_stat_player_hour_closes",
            schema: "dbo",
            columns: table => new
            {
                reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                stat_day_on = table.Column<DateOnly>(type: "date", nullable: false, comment: "統計日期時間"),
                count = table.Column<int>(type: "integer", precision: 18, scale: 6, nullable: false, defaultValue: 0, comment: "筆數"),
                bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_game_wager_stat_player_hour_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code, x.game_provider_id });
            });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_brand_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_on", "brand_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_brand_id_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_on", "brand_id", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_d_brand_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_day_on", "brand_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_d_brand_id_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_day_on", "brand_id", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_d_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_day_on", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_d_licensee_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_day_on", "licensee_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_d_reseller_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_day_on", "reseller_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_d_stat_day_on",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            column: "stat_day_on");

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_on", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_licensee_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_on", "licensee_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_reseller_id",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            columns: new[] { "stat_on", "reseller_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_h_c_stat_on",
            schema: "dbo",
            table: "game_wager_stat_brand_hour_closes",
            column: "stat_on");

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_brand_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_on", "brand_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_d_brand_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_day_on", "brand_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_d_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_day_on", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_d_licensee_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_day_on", "licensee_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_d_player_code",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_day_on", "player_code" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_d_player_code_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_day_on", "player_code", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_d_reseller_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_day_on", "reseller_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_d_stat_day_on",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            column: "stat_day_on");

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_on", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_licensee_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_on", "licensee_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_player_code",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_on", "player_code" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_player_code_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_on", "player_code", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_reseller_id",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            columns: new[] { "stat_on", "reseller_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_player_h_c_stat_on",
            schema: "dbo",
            table: "game_wager_stat_player_hour_closes",
            column: "stat_on");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "game_wager_stat_brand_hour_closes",
            schema: "dbo");

        migrationBuilder.DropTable(
            name: "game_wager_stat_player_hour_closes",
            schema: "dbo");
    }
}
