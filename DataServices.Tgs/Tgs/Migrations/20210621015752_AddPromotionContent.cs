using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPromotionContent : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "content",
            schema: "dbo",
            table: "promotions");

        _ = migrationBuilder.DropColumn(
            name: "desktop_banner",
            schema: "dbo",
            table: "promotions");

        _ = migrationBuilder.DropColumn(
            name: "localization",
            schema: "dbo",
            table: "promotions");

        _ = migrationBuilder.DropColumn(
            name: "mobile_banner",
            schema: "dbo",
            table: "promotions");

        _ = migrationBuilder.DropColumn(
            name: "sub_subject",
            schema: "dbo",
            table: "promotions");

        _ = migrationBuilder.DropColumn(
            name: "terms",
            schema: "dbo",
            table: "promotions");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "content",
            schema: "dbo",
            table: "promotions",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "desktop_banner",
            schema: "dbo",
            table: "promotions",
            type: "character varying(128)",
            maxLength: 128,
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "localization",
            schema: "dbo",
            table: "promotions",
            type: "jsonb",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "mobile_banner",
            schema: "dbo",
            table: "promotions",
            type: "character varying(128)",
            maxLength: 128,
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "sub_subject",
            schema: "dbo",
            table: "promotions",
            type: "character varying(2048)",
            maxLength: 2048,
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "terms",
            schema: "dbo",
            table: "promotions",
            type: "text",
            nullable: true);
    }
}
