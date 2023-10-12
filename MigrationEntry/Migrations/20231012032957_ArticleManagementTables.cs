using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class ArticleManagementTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "article_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    localized_articles = table.Column<string>(type: "jsonb", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    modifier = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_article_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_article_forms_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "draft_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    localized_articles = table.Column<string>(type: "jsonb", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    modifier = table.Column<string>(type: "text", nullable: false),
                    publish_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_draft_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_draft_forms_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_article_forms_brand_id",
                schema: "dbo",
                table: "article_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_draft_forms_brand_id",
                schema: "dbo",
                table: "draft_forms",
                column: "brand_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "draft_forms",
                schema: "dbo");
        }
    }
}
