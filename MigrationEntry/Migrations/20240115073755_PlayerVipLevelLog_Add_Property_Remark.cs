using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class PlayerVipLevelLog_Add_Property_Remark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "remark",
                schema: "dbo",
                table: "player_vip_level_logs",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "備註");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "remark",
                schema: "dbo",
                table: "player_vip_level_logs");
        }
    }
}
