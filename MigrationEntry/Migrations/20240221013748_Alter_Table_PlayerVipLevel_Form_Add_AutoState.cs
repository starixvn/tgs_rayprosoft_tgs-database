using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_PlayerVipLevel_Form_Add_AutoState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "自動狀態(True:自動;False:手動)");

            migrationBuilder.AlterColumn<bool>(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_exp_forms",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "自動狀態(True:自動;False:手動)",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "自動狀態(True:自動;False:手動)");

            migrationBuilder.AddColumn<bool>(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_cycle_forms",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "自動狀態(True:自動;False:手動)");

            migrationBuilder.AddColumn<bool>(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_birthday_forms",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "自動狀態(True:自動;False:手動)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms");

            migrationBuilder.DropColumn(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_cycle_forms");

            migrationBuilder.DropColumn(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_birthday_forms");

            migrationBuilder.AlterColumn<bool>(
                name: "auto_state",
                schema: "dbo",
                table: "player_vip_level_exp_forms",
                type: "boolean",
                nullable: false,
                comment: "自動狀態(True:自動;False:手動)",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true,
                oldComment: "自動狀態(True:自動;False:手動)");
        }
    }
}
