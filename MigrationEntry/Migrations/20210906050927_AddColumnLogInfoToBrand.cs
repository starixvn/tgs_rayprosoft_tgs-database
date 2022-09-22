using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddColumnLogInfoToBrand : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "logo_info",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "logo_info",
            schema: "dbo",
            table: "brands",
            type: "jsonb",
            nullable: true);
    }
}
