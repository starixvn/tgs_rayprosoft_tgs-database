using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_GameWagerPlayerAccum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_wager_player_accums",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    accum_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "累積時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("pk_game_wager_player_accums", x => new { x.accum_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_accum_on",
                schema: "dbo",
                table: "game_wager_player_accums",
                column: "accum_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_brand_id",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_licensee_id",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_player_code",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_reseller_id",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "reseller_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_player_accums",
                schema: "dbo");
        }
    }
}
