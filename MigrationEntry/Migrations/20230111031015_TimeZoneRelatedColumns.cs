using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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

            migrationBuilder.CreateIndex(
                name: "ix_player_game_rebate_aggregates_new_multiple_keys",
                schema: "report",
                table: "player_game_rebate_aggregates",
                columns: new[] { "report_date_time", "brand_id", "agent_id", "player_code" })
                .Annotation("Npgsql:IndexSortOrder", new[] { SortOrder.Descending, SortOrder.Ascending, SortOrder.Ascending, SortOrder.Ascending });

            migrationBuilder.CreateIndex(
                name: "ix_player_bonus_aggregates_new_multiple_keys",
                schema: "report",
                table: "player_bonus_aggregates",
                columns: new[] { "report_date_time", "brand_id", "agent_id", "player_code" })
                .Annotation("Npgsql:IndexSortOrder", new[] { SortOrder.Descending, SortOrder.Ascending, SortOrder.Ascending, SortOrder.Ascending });

            migrationBuilder.CreateIndex(
                name: "ix_player_aggregates_new_multiple_keys",
                schema: "report",
                table: "player_aggregates",
                columns: new[] { "report_date_time", "brand_id", "agent_id", "player_code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_player_game_rebate_aggregates_new_multiple_keys",
                schema: "report",
                table: "player_game_rebate_aggregates");

            migrationBuilder.DropIndex(
                name: "ix_player_bonus_aggregates_new_multiple_keys",
                schema: "report",
                table: "player_bonus_aggregates");

            migrationBuilder.DropIndex(
                name: "ix_player_aggregates_new_multiple_keys",
                schema: "report",
                table: "player_aggregates");

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
