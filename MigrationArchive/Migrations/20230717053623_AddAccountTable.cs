using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddAccountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account_event_sources",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_event_sources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    algorithm = table.Column<string>(type: "text", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.UniqueConstraint("ux_accounts_username_system_brand", x => new { x.user_name, x.system, x.brand_id });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_event_sources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "dbo");
        }
    }
}
