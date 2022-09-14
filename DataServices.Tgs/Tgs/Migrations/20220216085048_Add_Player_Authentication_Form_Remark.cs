using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Add_Player_Authentication_Form_Remark : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "remark",
            schema: "dbo",
            table: "player_authentication_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "remark",
            schema: "dbo",
            table: "player_authentication_forms",
            type: "text",
            nullable: true);
    }
}
