using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Tabel_PlayerVipLevelBirthdayForm_PlayerVipLevelCycleForm_uni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_player_vip_level_cycle_f_player_code_cycle",
                schema: "dbo",
                table: "player_vip_level_cycle_forms");

            migrationBuilder.DropIndex(
                name: "ix_player_vip_level_b_f_player_code_birthday",
                schema: "dbo",
                table: "player_vip_level_birthday_forms");

            migrationBuilder.CreateIndex(
                name: "uni_player_vip_level_cycle_f_player_code_cycle",
                schema: "dbo",
                table: "player_vip_level_cycle_forms",
                columns: new[] { "player_code", "cycle_type", "cycle_on" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uni_player_vip_level_b_f_player_code_birthday",
                schema: "dbo",
                table: "player_vip_level_birthday_forms",
                columns: new[] { "player_code", "birthday" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "uni_player_vip_level_cycle_f_player_code_cycle",
                schema: "dbo",
                table: "player_vip_level_cycle_forms");

            migrationBuilder.DropIndex(
                name: "uni_player_vip_level_b_f_player_code_birthday",
                schema: "dbo",
                table: "player_vip_level_birthday_forms");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_cycle_f_player_code_cycle",
                schema: "dbo",
                table: "player_vip_level_cycle_forms",
                columns: new[] { "player_code", "cycle_type", "cycle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_b_f_player_code_birthday",
                schema: "dbo",
                table: "player_vip_level_birthday_forms",
                columns: new[] { "player_code", "birthday" });
        }
    }
}
