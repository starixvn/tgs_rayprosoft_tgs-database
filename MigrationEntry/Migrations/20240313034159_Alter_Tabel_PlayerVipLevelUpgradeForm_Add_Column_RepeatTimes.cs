using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Tabel_PlayerVipLevelUpgradeForm_Add_Column_RepeatTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "repeat_times",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "重複次數");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "repeat_times",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms");
        }
    }
}
