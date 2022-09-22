using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddComboColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "combo",
            schema: "dbo",
            table: "sign_in_events");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<int>(
            name: "combo",
            schema: "dbo",
            table: "sign_in_events",
            type: "integer",
            nullable: false,
            defaultValue: 1);
    }
}
