using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class GameWagerStatHourClose_Add_Column_DefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+08:00:00':: interval",
                comment: "統計時間跨度",
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldDefaultValueSql: "'+00:00:00':: interval",
                oldComment: "統計時間跨度");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "stat_hour_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                type: "time without time zone",
                nullable: false,
                defaultValueSql: "'00:00:00':: time",
                comment: "統計小時時間",
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldComment: "統計小時時間");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                type: "date",
                nullable: false,
                defaultValueSql: "'1990-01-01':: date",
                comment: "統計日時間",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComment: "統計日時間");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+08:00:00':: interval",
                comment: "統計時間跨度",
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldDefaultValueSql: "'+00:00:00':: interval",
                oldComment: "統計時間跨度");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "stat_hour_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                type: "time without time zone",
                nullable: false,
                defaultValueSql: "'00:00:00':: time",
                comment: "統計小時時間",
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldComment: "統計小時時間");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                type: "date",
                nullable: false,
                defaultValueSql: "'1990-01-01':: date",
                comment: "統計日時間",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldComment: "統計日時間");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+00:00:00':: interval",
                comment: "統計時間跨度",
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldDefaultValueSql: "'+08:00:00':: interval",
                oldComment: "統計時間跨度");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "stat_hour_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                type: "time without time zone",
                nullable: false,
                comment: "統計小時時間",
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldDefaultValueSql: "'00:00:00':: time",
                oldComment: "統計小時時間");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                type: "date",
                nullable: false,
                comment: "統計日時間",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "'1990-01-01':: date",
                oldComment: "統計日時間");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+00:00:00':: interval",
                comment: "統計時間跨度",
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldDefaultValueSql: "'+08:00:00':: interval",
                oldComment: "統計時間跨度");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "stat_hour_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                type: "time without time zone",
                nullable: false,
                comment: "統計小時時間",
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone",
                oldDefaultValueSql: "'00:00:00':: time",
                oldComment: "統計小時時間");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                type: "date",
                nullable: false,
                comment: "統計日時間",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "'1990-01-01':: date",
                oldComment: "統計日時間");
        }
    }
}
