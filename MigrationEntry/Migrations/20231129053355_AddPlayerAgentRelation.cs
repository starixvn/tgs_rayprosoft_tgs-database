using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayerAgentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_agent_relations",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_id_player_code_agent_id", x => new { x.brand_id, x.player_code, x.agent_id });
                    table.ForeignKey(
                        name: "fk_player_agents_agents_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_agents_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_agents_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_agent_relations_agent_id",
                schema: "dbo",
                table: "player_agent_relations",
                column: "agent_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_agent_relations_brand_id",
                schema: "dbo",
                table: "player_agent_relations",
                column: "brand_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_agent_relations_player_code",
                schema: "dbo",
                table: "player_agent_relations",
                column: "player_code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_agent_relations",
                schema: "dbo");
        }
    }
}
