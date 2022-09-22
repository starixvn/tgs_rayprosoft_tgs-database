using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAutoClearWageringRequirementBalance : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "auto_clear_wagering_requirement_balance",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "auto_clear_wagering_requirement_balance",
            schema: "dbo",
            table: "brands",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
