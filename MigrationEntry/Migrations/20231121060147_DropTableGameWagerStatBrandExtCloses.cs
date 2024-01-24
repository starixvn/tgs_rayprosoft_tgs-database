using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class DropTableGameWagerStatBrandExtCloses : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "game_wager_stat_brand_ext_closes",
            schema: "dbo");

        migrationBuilder.DropIndex(
            name: "ix_game_wager_stat_brand_closes_id",
            schema: "dbo",
            table: "game_wager_stat_brand_closes");

        migrationBuilder.DropColumn(
            name: "id",
            schema: "dbo",
            table: "game_wager_stat_brand_closes");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<long>(
            name: "id",
            schema: "dbo",
            table: "game_wager_stat_brand_closes",
            type: "bigint",
            nullable: false,
            defaultValue: 0L,
            comment: "識別碼");

        migrationBuilder.CreateTable(
            name: "game_wager_stat_brand_ext_closes",
            schema: "dbo",
            columns: table => new
            {
                stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                count = table.Column<int>(type: "integer", precision: 18, scale: 6, nullable: false, defaultValue: 0, comment: "筆數"),
                created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                id = table.Column<long>(type: "bigint", nullable: false, comment: "識別碼"),
                settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_game_wager_stat_brand_ext_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.game_provider_id });
            });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_closes_id",
            schema: "dbo",
            table: "game_wager_stat_brand_closes",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_ext_closes_brand_id",
            schema: "dbo",
            table: "game_wager_stat_brand_ext_closes",
            columns: new[] { "stat_on", "brand_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_ext_closes_brand_id_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_brand_ext_closes",
            columns: new[] { "stat_on", "brand_id", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_ext_closes_game_provider_id",
            schema: "dbo",
            table: "game_wager_stat_brand_ext_closes",
            columns: new[] { "stat_on", "game_provider_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_ext_closes_id",
            schema: "dbo",
            table: "game_wager_stat_brand_ext_closes",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_ext_closes_licensee_id",
            schema: "dbo",
            table: "game_wager_stat_brand_ext_closes",
            columns: new[] { "stat_on", "licensee_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_ext_closes_reseller_id",
            schema: "dbo",
            table: "game_wager_stat_brand_ext_closes",
            columns: new[] { "stat_on", "reseller_id" });

        migrationBuilder.CreateIndex(
            name: "ix_game_wager_stat_brand_ext_closes_stat_on",
            schema: "dbo",
            table: "game_wager_stat_brand_ext_closes",
            column: "stat_on");
    }
}
