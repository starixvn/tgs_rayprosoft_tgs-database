using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AdjustPromotionRebateDailyStatisticsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rebate_amount",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics",
                newName: "bucket_amount");

            migrationBuilder.AddColumn<decimal>(
                name: "bonus",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "settings",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bonus",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics");

            migrationBuilder.DropColumn(
                name: "settings",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics");

            migrationBuilder.RenameColumn(
                name: "bucket_amount",
                schema: "dbo",
                table: "promotion_rebate_daily_statistics",
                newName: "rebate_amount");
        }
    }
}
