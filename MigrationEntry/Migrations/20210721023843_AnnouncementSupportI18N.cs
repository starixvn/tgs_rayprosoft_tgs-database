using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AnnouncementSupportI18N : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "language_content",
            schema: "dbo",
            table: "announcements");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "language_content",
            schema: "dbo",
            table: "announcements",
            type: "jsonb",
            nullable: true);
    }
}
