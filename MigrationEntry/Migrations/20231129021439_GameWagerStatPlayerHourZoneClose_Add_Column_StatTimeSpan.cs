using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class GameWagerStatPlayerHourZoneClose_Add_Column_StatTimeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_player_hour_zone_closes",
                type: "interval",
                nullable: false,
                defaultValueSql: "'+00:00:00':: interval",
                comment: "時區");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "stat_time_span",
                schema: "dbo",
                table: "game_wager_stat_player_hour_zone_closes");
        }
    }
}
