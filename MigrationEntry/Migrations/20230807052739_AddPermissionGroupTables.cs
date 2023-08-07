using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPermissionGroupTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "ak_functions_name_system",
                schema: "dbo",
                table: "functions",
                columns: new[] { "name", "system" });

            migrationBuilder.CreateTable(
                name: "groups",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groups", x => x.id);
                    table.UniqueConstraint("ak_groups_name_system", x => new { x.name, x.system });
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    function_id = table.Column<Guid>(type: "uuid", nullable: false),
                    identity = table.Column<string>(type: "text", nullable: false),
                    identity_type = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    fk_functions = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_functions_function_id",
                        column: x => x.fk_functions,
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

            migrationBuilder.CreateTable(
                name: "group_users",
                schema: "dbo",
                columns: table => new
                {
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group_users", x => new { x.group_id, x.user_id, x.system });
                    table.ForeignKey(
                        name: "fk_groups",
                        column: x => x.group_id,
                        principalSchema: "dbo",
                        principalTable: "groups",
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
                name: "ix_group_users_system",
                schema: "dbo",
                table: "group_users",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_groups_system",
                schema: "dbo",
                table: "groups",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_fk_functions",
                schema: "dbo",
                table: "permissions",
                column: "fk_functions");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_system",
                schema: "dbo",
                table: "permissions",
                column: "system");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_systems",
                schema: "dbo",
                table: "function_event_sources");

            migrationBuilder.DropForeignKey(
                name: "fk_systems",
                schema: "dbo",
                table: "functions");

            migrationBuilder.DropTable(
                name: "group_users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "groups",
                schema: "dbo");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_functions_name_system",
                schema: "dbo",
                table: "functions");
        }
    }
}
