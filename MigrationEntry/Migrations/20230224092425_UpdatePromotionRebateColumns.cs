using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class UpdatePromotionRebateColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "distribute_date",
                schema: "dbo",
                table: "promotion_rebate_distributes");

            migrationBuilder.AddColumn<decimal>(
                name: "bonus",
                schema: "dbo",
                table: "promotion_relief_daily_statistics",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "bucket_amount",
                schema: "dbo",
                table: "promotion_relief_daily_statistics",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "report_date_time",
                schema: "dbo",
                table: "promotion_relief_daily_statistics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "distribute_from",
                schema: "dbo",
                table: "promotion_rebate_distributes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "distribute_to",
                schema: "dbo",
                table: "promotion_rebate_distributes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "report_date_time",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bonus",
                schema: "dbo",
                table: "promotion_relief_daily_statistics");

            migrationBuilder.DropColumn(
                name: "bucket_amount",
                schema: "dbo",
                table: "promotion_relief_daily_statistics");

            migrationBuilder.DropColumn(
                name: "report_date_time",
                schema: "dbo",
                table: "promotion_relief_daily_statistics");

            migrationBuilder.DropColumn(
                name: "distribute_from",
                schema: "dbo",
                table: "promotion_rebate_distributes");

            migrationBuilder.DropColumn(
                name: "distribute_to",
                schema: "dbo",
                table: "promotion_rebate_distributes");

            migrationBuilder.DropColumn(
                name: "report_date_time",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics");

            migrationBuilder.AddColumn<DateOnly>(
                name: "distribute_date",
                schema: "dbo",
                table: "promotion_rebate_distributes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
