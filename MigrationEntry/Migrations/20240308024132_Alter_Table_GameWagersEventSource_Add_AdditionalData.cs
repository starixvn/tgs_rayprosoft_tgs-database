using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagersEventSource_Add_AdditionalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "additional_data",
                schema: "dbo",
                table: "game_wagers_event_sources",
                type: "jsonb",
                nullable: false,
                defaultValue: "{}",
                comment: "附加數據");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "additional_data",
                schema: "dbo",
                table: "game_wagers_event_sources");
        }
    }
}
