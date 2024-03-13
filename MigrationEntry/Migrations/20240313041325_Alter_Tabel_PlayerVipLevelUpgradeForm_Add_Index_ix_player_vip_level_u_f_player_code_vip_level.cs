using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Tabel_PlayerVipLevelUpgradeForm_Add_Index_ix_player_vip_level_u_f_player_code_vip_level : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_u_f_player_code_vip_level",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms",
                columns: new[] { "player_code", "vip_level" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_player_vip_level_u_f_player_code_vip_level",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms");
        }
    }
}
