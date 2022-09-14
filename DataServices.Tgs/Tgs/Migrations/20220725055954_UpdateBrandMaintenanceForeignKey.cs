using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateBrandMaintenanceForeignKey : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ix_brand_maintenance_brand_id",
            schema: "dbo",
            table: "brand_maintenance");

        _ = migrationBuilder.CreateIndex(
            name: "ix_brand_maintenance_brand_id",
            schema: "dbo",
            table: "brand_maintenance",
            column: "brand_id");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ix_brand_maintenance_brand_id",
            schema: "dbo",
            table: "brand_maintenance");

        _ = migrationBuilder.CreateIndex(
            name: "ix_brand_maintenance_brand_id",
            schema: "dbo",
            table: "brand_maintenance",
            column: "brand_id",
            unique: true);
    }
}
