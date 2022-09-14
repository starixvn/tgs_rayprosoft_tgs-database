using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddEnableBankInfoRegisterFlowToBrandTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "enable_bank_info_register_flow",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<bool>(
            name: "enable_bank_info_register_flow",
            schema: "dbo",
            table: "brands",
            type: "boolean",
            nullable: false,
            defaultValue: false);
    }
}
