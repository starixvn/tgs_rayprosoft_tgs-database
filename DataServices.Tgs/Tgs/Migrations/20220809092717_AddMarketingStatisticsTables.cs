using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddMarketingStatisticsTables : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "player_daily_gaming_statistics",
            schema: "dbo");

        _ = migrationBuilder.DropTable(
            name: "player_daily_register_statistics",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "player_daily_gaming_statistics",
            schema: "dbo",
            columns: table => new
            {
                player_code = table.Column<string>(type: "text", nullable: false),
                report_date = table.Column<DateOnly>(type: "date", nullable: false),
                gp_code = table.Column<string>(type: "text", nullable: false),
                sub_gp_code = table.Column<string>(type: "text", nullable: false),
                win_loss = table.Column<decimal>(type: "numeric", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_player_daily_gaming_statistics", x => new { x.report_date, x.player_code });
            });

        _ = migrationBuilder.CreateTable(
            name: "player_daily_register_statistics",
            schema: "dbo",
            columns: table => new
            {
                player_code = table.Column<string>(type: "text", nullable: false),
                report_date = table.Column<DateOnly>(type: "date", nullable: false),
                daily_login_count = table.Column<int>(type: "integer", nullable: false),
                last_login_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                total_login_count = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_player_daily_register_statistics", x => new { x.report_date, x.player_code });
            });
    }
}
