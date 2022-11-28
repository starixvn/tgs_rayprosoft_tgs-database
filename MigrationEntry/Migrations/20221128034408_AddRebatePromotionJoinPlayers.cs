using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddRebatePromotionJoinPlayers : Migration
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

            migrationBuilder.CreateTable(
                name: "rebate_promotion_join_players",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rebate_promotion_join_players", x => new { x.promotion_id, x.player_code });
                    table.ForeignKey(
                        name: "fk_players_rebate_promotion_join_players",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promotions_rebate_promotion_join_players",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_rebate_promotion_join_players_player_code",
                schema: "dbo",
                table: "rebate_promotion_join_players",
                column: "player_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "promotion_groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "rebate_promotion_join_players",
                schema: "dbo");
        }
    }
}
