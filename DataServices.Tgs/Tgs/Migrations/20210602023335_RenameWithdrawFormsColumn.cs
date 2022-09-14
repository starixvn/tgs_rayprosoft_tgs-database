using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RenameWithdrawFormsColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.RenameColumn(
            name: "user_id",
            schema: "dbo",
            table: "withdraw_forms",
            newName: "player_code");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.RenameColumn(
            name: "player_code",
            schema: "dbo",
            table: "withdraw_forms",
            newName: "user_id");
    }
}
