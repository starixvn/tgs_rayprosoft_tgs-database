using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class StationLetterSupportI18N : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "language_content",
            schema: "dbo",
            table: "station_letters");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "language_content",
            schema: "dbo",
            table: "station_letters",
            type: "jsonb",
            nullable: true);
    }
}
