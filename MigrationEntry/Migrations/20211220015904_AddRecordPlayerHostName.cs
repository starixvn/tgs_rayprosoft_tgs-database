using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddRecordPlayerHostName : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "host",
            schema: "dbo",
            table: "player_ip_records");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "host",
            schema: "dbo",
            table: "player_ip_records",
            type: "character varying(250)",
            maxLength: 250,
            nullable: true);
    }
}
