using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddColumnEnableSmsRegFlowToBrand : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "enable_sms_register_flow",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<bool>(
            name: "enable_sms_register_flow",
            schema: "dbo",
            table: "brands",
            type: "boolean",
            nullable: false,
            defaultValue: false);
    }
}
