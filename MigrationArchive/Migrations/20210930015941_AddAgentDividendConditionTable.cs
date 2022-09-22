using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAgentDividendConditionTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "agent_dividend_conditions",
            schema: "dbo");

        _ = migrationBuilder.DropColumn(
            name: "check_dividend_active_count",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<bool>(
            name: "check_dividend_active_count",
            schema: "dbo",
            table: "brands",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        _ = migrationBuilder.CreateTable(
            name: "agent_dividend_conditions",
            schema: "dbo",
            columns: table => new
            {
                rank = table.Column<int>(type: "integer", nullable: false),
                agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                active_number = table.Column<int>(type: "integer", nullable: false),
                dividend_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_agent_dividend_conditions_rank_agent_id", x => new { x.rank, x.agent_id });
                _ = table.ForeignKey(
                    name: "fk_agents_dividend_conditions_agent_id",
                    column: x => x.agent_id,
                    principalSchema: "dbo",
                    principalTable: "agents",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_agent_dividend_conditions_agent_id",
            schema: "dbo",
            table: "agent_dividend_conditions",
            column: "agent_id");
    }
}
