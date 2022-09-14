using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBannerOrderColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "display_order",
            schema: "dbo",
            table: "banners");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<int>(
            name: "display_order",
            schema: "dbo",
            table: "banners",
            type: "integer",
            nullable: false,
            defaultValue: 1);
    }
}
