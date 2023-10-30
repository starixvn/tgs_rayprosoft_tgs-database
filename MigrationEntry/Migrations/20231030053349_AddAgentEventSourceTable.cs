using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddAgentEventSourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agent_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: true),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_event_source", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agent_event_source",
                schema: "dbo");
        }
    }
}
