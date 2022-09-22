using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAdjustColumnForAgentDividend : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "agent_adjust_amount",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.RenameColumn(
            name: "company_adjust_amount",
            schema: "dbo",
            table: "agent_dividends",
            newName: "adjustment_amount");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.RenameColumn(
            name: "adjustment_amount",
            schema: "dbo",
            table: "agent_dividends",
            newName: "company_adjust_amount");

        _ = migrationBuilder.AddColumn<decimal>(
            name: "agent_adjust_amount",
            schema: "dbo",
            table: "agent_dividends",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
