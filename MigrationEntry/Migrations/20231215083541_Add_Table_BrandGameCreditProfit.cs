using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_BrandGameCreditProfit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand_game_credit_profits",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    month = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "月份"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利")
                },
                constraints: table =>
                {
                    table.PrimaryKey("ix_brand_game_credit_brand_id", x => new { x.brand_id, x.month });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_game_credit_profits",
                schema: "dbo");
        }
    }
}
