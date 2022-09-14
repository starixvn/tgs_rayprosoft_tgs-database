using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPlatformChargeColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "platform_charge",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "platform_charge",
            schema: "dbo",
            table: "brands",
            type: "numeric(9,6)",
            precision: 9,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
