using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddSmsColumns : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "area_code",
            schema: "dbo",
            table: "players");

        _ = migrationBuilder.DropColumn(
            name: "enable_sms",
            schema: "dbo",
            table: "brands");

        _ = migrationBuilder.DropColumn(
            name: "sms_vendor_code",
            schema: "dbo",
            table: "brands");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "area_code",
            schema: "dbo",
            table: "players",
            type: "character varying(10)",
            maxLength: 10,
            nullable: true);

        _ = migrationBuilder.AddColumn<bool>(
            name: "enable_sms",
            schema: "dbo",
            table: "brands",
            type: "boolean",
            nullable: false,
            defaultValue: false);

        _ = migrationBuilder.AddColumn<string>(
            name: "sms_vendor_code",
            schema: "dbo",
            table: "brands",
            type: "text",
            nullable: true);
    }
}
