using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RenameAnnouncementStationLetterI18NColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.RenameColumn(
            name: "localization",
            schema: "dbo",
            table: "station_letters",
            newName: "language_content");

        _ = migrationBuilder.RenameColumn(
            name: "localization",
            schema: "dbo",
            table: "announcements",
            newName: "language_content");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.RenameColumn(
            name: "language_content",
            schema: "dbo",
            table: "station_letters",
            newName: "localization");

        _ = migrationBuilder.RenameColumn(
            name: "language_content",
            schema: "dbo",
            table: "announcements",
            newName: "localization");
    }
}
