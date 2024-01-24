using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

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
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
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
