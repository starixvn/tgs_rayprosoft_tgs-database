using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_PlayerVipLevelBirthdayForm_Edit_VipLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "level",
                schema: "dbo",
                table: "player_vip_level_birthday_forms");

            migrationBuilder.AddColumn<int>(
                name: "vip_level",
                schema: "dbo",
                table: "player_vip_level_birthday_forms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Vip等級");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vip_level",
                schema: "dbo",
                table: "player_vip_level_birthday_forms");

            migrationBuilder.AddColumn<int>(
                name: "level",
                schema: "dbo",
                table: "player_vip_level_birthday_forms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "等級");
        }
    }
}
