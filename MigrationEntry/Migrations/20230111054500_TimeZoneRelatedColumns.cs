using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class TimeZoneRelatedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "report_date_time",
                schema: "report",
                table: "player_game_rebate_aggregates",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "report_date_time",
                schema: "report",
                table: "player_bonus_aggregates",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "report_date_time",
                schema: "report",
                table: "player_aggregates",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "time_span_minutes",
                schema: "dbo",
                table: "brands",
                type: "integer",
                nullable: true,
                defaultValue: 480);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "report_date_time",
                schema: "report",
                table: "player_game_rebate_aggregates");

            migrationBuilder.DropColumn(
                name: "report_date_time",
                schema: "report",
                table: "player_bonus_aggregates");

            migrationBuilder.DropColumn(
                name: "report_date_time",
                schema: "report",
                table: "player_aggregates");

            migrationBuilder.DropColumn(
                name: "time_span_minutes",
                schema: "dbo",
                table: "brands");
        }
    }
}
