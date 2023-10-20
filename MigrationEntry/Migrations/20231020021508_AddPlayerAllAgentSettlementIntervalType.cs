using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayerAllAgentSettlementIntervalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "player_all_agent_settlement_interval_type",
                schema: "dbo",
                table: "brands",
                type: "smallint",
                nullable: false,
                defaultValue: (short)3);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                type: "timestamp with time zone",
                nullable: false,
                computedColumnSql: "report_date",
                stored: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebate_records_from_to_brand_id_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                columns: new[] { "from", "to", "brand_id", "player_code", "all_agent_rebate_type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebate_contributors_from_to_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                columns: new[] { "from", "to", "player_code", "child_player_code" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_player_all_agent_rebate_records_from_to_brand_id_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records");

            migrationBuilder.DropIndex(
                name: "ix_player_all_agent_rebate_contributors_from_to_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors");

            migrationBuilder.DropColumn(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_records");

            migrationBuilder.DropColumn(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_records");

            migrationBuilder.DropColumn(
                name: "from",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors");

            migrationBuilder.DropColumn(
                name: "to",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors");

            migrationBuilder.DropColumn(
                name: "player_all_agent_settlement_interval_type",
                schema: "dbo",
                table: "brands");
        }
    }
}
