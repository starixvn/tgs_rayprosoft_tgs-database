using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_PlayerVipLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_vip_levels",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    vip_level_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "VipLevel識別碼"),
                    vip_level = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "VipLevel等級"),
                    auto_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "自動狀態(0:啟用 1:停用)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_levels", x => x.player_code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_vip_levels",
                schema: "dbo");
        }
    }
}
