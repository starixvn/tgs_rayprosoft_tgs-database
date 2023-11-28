using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_GameWagerStatBrandHourZoneClose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_wager_stat_brand_hour_zone_closes",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                    stat_day_on = table.Column<DateOnly>(type: "date", nullable: false, comment: "統計日時間"),
                    stat_hour_on = table.Column<TimeOnly>(type: "time without time zone", nullable: false, comment: "統計小時時間"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
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
                    table.PrimaryKey("pk_game_wager_stat_brand_hour_zone_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.game_provider_id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_brand_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_h_brand_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_h_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_h_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_h_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_h_stat_hour_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "stat_day_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                columns: new[] { "stat_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_z_c_stat_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                column: "stat_on");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_stat_brand_hour_zone_closes",
                schema: "dbo");
        }
    }
}
