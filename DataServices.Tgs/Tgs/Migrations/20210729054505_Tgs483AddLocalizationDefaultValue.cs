using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Tgs483AddLocalizationDefaultValue : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<string>(
            name: "localization",
            schema: "dbo",
            table: "station_letters",
            type: "jsonb",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "jsonb",
            oldDefaultValue: "{}");

        _ = migrationBuilder.AlterColumn<string>(
            name: "localization",
            schema: "dbo",
            table: "announcements",
            type: "jsonb",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "jsonb",
            oldDefaultValue: "{}");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<string>(
            name: "localization",
            schema: "dbo",
            table: "station_letters",
            type: "jsonb",
            nullable: false,
            defaultValue: "{}",
            oldClrType: typeof(string),
            oldType: "jsonb",
            oldNullable: true);

        _ = migrationBuilder.AlterColumn<string>(
            name: "localization",
            schema: "dbo",
            table: "announcements",
            type: "jsonb",
            nullable: false,
            defaultValue: "{}",
            oldClrType: typeof(string),
            oldType: "jsonb",
            oldNullable: true);
    }
}
