using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBeforeDividendAmountColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            "referenced_agent_dividend_id",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.DropColumn(
            "before_dividend_amount",
            schema: "dbo",
            table: "agent_dividends");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<int>(
            "referenced_agent_dividend_id",
            schema: "dbo",
            table: "agent_dividends",
            type: "integer",
            nullable: true);

        _ = migrationBuilder.AddColumn<decimal>(
            "before_dividend_amount",
            schema: "dbo",
            table: "agent_dividends",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: true);
    }
}
