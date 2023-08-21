using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPromotionSettingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "promotion_groups",
                schema: "dbo",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    translate = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_groups", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "promotion_types",
                schema: "dbo",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    extend = table.Column<string>(type: "jsonb", nullable: true),
                    translate = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_types", x => x.name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "promotion_groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_types",
                schema: "dbo");
        }
    }
}
