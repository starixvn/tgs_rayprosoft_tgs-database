using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAgentDomainsTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "agent_domains",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "agent_domains",
            schema: "dbo",
            columns: table => new
            {
                agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                domain_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_agent_domains", x => new { x.agent_id, x.domain_name });
                _ = table.ForeignKey(
                    name: "fk_agent_domains_agents_agent_id",
                    column: x => x.agent_id,
                    principalSchema: "dbo",
                    principalTable: "agents",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });
    }
}
