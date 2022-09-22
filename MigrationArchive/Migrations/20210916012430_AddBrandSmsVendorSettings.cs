using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBrandSmsVendorSettings : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "sms_vendor_settings",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "sms_vendor_settings",
            schema: "dbo",
            table: "brands",
            type: "jsonb",
            nullable: true);
    }
}
