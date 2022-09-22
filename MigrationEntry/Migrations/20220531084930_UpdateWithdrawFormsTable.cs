using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateWithdrawFormsTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "note",
            schema: "dbo",
            table: "withdraw_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "note",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true);
    }
}
