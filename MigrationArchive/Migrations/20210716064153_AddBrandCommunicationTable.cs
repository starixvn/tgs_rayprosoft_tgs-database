using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBrandCommunicationTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "brand_communications",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "brand_communications",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                app_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                qr_code_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_brand_communications", x => x.id);
                _ = table.ForeignKey(
                    name: "fk_brand_communications_brands_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_brand_communications_brand_id",
            schema: "dbo",
            table: "brand_communications",
            column: "brand_id");
    }
}
