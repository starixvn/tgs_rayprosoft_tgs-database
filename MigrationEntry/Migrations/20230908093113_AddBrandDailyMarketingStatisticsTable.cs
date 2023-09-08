using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddBrandDailyMarketingStatisticsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand_daily_marketing_statistics",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    directly_player_gaming_count = table.Column<int>(type: "integer", nullable: true, comment: "無直屬代理的玩家遊戲人數"),
                    directly_player_register_count = table.Column<int>(type: "integer", nullable: true, comment: "無直屬代理的玩家註冊人數"),
                    total_player_gaming_count = table.Column<int>(type: "integer", nullable: true, comment: "玩家總遊戲人數"),
                    total_player_register_count = table.Column<int>(type: "integer", nullable: true, comment: "玩家總註冊人數")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_daily_marketing_statistics", x => new { x.report_date, x.brand_id });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_daily_marketing_statistics",
                schema: "dbo");
        }
    }
}
