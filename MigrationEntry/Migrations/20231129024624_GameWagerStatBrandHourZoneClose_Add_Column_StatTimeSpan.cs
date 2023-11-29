using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class GameWagerStatBrandHourZoneClose_Add_Column_StatTimeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_player_hour_zone_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+00:00:00':: interval",
                comment: "統計時間跨度",
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldDefaultValueSql: "'+00:00:00':: interval",
                oldComment: "時區");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+00:00:00':: interval",
                comment: "統計時間跨度");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_zone_closes");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_player_hour_zone_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+00:00:00':: interval",
                comment: "時區",
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldDefaultValueSql: "'+00:00:00':: interval",
                oldComment: "統計時間跨度");
        }
    }
}
