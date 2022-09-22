using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateAgentDividendTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "bonus_adjust_amount",
            schema: "dbo",
            table: "agent_dividends");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "bonus_adjust_amount",
            schema: "dbo",
            table: "agent_dividends",
            type: "numeric",
            nullable: false,
            defaultValue: 0m);
    }
}
