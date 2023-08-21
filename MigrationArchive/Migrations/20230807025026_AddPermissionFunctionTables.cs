using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPermissionFunctionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "systems",
                schema: "dbo",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_systems", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "functions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    features = table.Column<string>(type: "jsonb", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_functions", x => x.id);
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "function_event_sources",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    function_id = table.Column<Guid>(type: "uuid", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_function_event_sources", x => x.id);
                    table.ForeignKey(
                        name: "fk_functions",
                        column: x => x.function_id,
                        principalSchema: "dbo",
                        principalTable: "functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_function_event_sources_function_id",
                schema: "dbo",
                table: "function_event_sources",
                column: "function_id");

            migrationBuilder.CreateIndex(
                name: "ix_function_event_sources_system",
                schema: "dbo",
                table: "function_event_sources",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_functions_system",
                schema: "dbo",
                table: "functions",
                column: "system");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "function_event_sources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "functions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "systems",
                schema: "dbo");
        }
    }
}
