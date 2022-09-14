using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBrandAgentDividendConditionTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "brand_agent_dividend_conditions",
            schema: "dbo");

        _ = migrationBuilder.DropColumn(
            name: "agent_dividend_type",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<short>(
            name: "agent_dividend_type",
            schema: "dbo",
            table: "brands",
            type: "smallint",
            nullable: false,
            defaultValue: (short)0);

        _ = migrationBuilder.CreateTable(
            name: "brand_agent_dividend_conditions",
            schema: "dbo",
            columns: table => new
            {
                rank = table.Column<int>(type: "integer", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                active_number = table.Column<int>(type: "integer", nullable: false),
                dividend_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_brand_agent_dividend_conditions_rank_brand_id", x => new { x.rank, x.brand_id });
                _ = table.ForeignKey(
                    name: "fk_brand_agent_dividend_conditions_brands_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_brand_agent_dividend_conditions_brand_id",
            schema: "dbo",
            table: "brand_agent_dividend_conditions",
            column: "brand_id");
    }
}
