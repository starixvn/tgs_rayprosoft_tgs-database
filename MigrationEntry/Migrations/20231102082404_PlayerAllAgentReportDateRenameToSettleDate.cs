using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class PlayerAllAgentReportDateRenameToSettleDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_player_all_agent_rebate_records_from_to_brand_id_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records");

            migrationBuilder.RenameColumn(
                name: "report_date",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                newName: "settle_date");

            migrationBuilder.RenameIndex(
                name: "ix_player_all_agent_rebate_records_report_date_brand_id_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                newName: "ix_player_all_agent_rebate_records_settle_date_brand_id_player_code");

            migrationBuilder.RenameColumn(
                name: "report_date",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                newName: "settle_date");

            migrationBuilder.RenameIndex(
                name: "ix_player_all_agent_rebate_contributors_report_date_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                newName: "ix_player_all_agent_rebate_contributors_settle_date_player_code");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldComputedColumnSql: "report_date");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldComputedColumnSql: "report_date");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldComputedColumnSql: "report_date");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldComputedColumnSql: "report_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "settle_date",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                newName: "report_date");

            migrationBuilder.RenameIndex(
                name: "ix_player_all_agent_rebate_records_settle_date_brand_id_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                newName: "ix_player_all_agent_rebate_records_report_date_brand_id_player_code");

            migrationBuilder.RenameColumn(
                name: "settle_date",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                newName: "report_date");

            migrationBuilder.RenameIndex(
                name: "ix_player_all_agent_rebate_contributors_settle_date_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                newName: "ix_player_all_agent_rebate_contributors_report_date_player_code");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebate_records_from_to_brand_id_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                columns: new[] { "from", "to", "brand_id", "player_code", "all_agent_rebate_type" },
                unique: true);
        }
    }
}
