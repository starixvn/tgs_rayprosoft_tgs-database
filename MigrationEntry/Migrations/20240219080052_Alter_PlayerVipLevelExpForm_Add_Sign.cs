using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_PlayerVipLevelExpForm_Add_Sign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sign",
                schema: "dbo",
                table: "player_vip_level_exp_forms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "符號(1:正號 -1:負號)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sign",
                schema: "dbo",
                table: "player_vip_level_exp_forms");
        }
    }
}
