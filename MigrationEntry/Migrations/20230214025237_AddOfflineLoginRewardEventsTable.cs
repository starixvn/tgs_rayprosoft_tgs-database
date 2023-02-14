using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddOfflineLoginRewardEventsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "offline_login_reward_events",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    logged_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offline_login_reward_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_offline_login_reward_events_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offline_login_reward_events_players_brand_id",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offline_login_reward_events_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_offline_login_reward_events_brand_id",
                schema: "dbo",
                table: "offline_login_reward_events",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_offline_login_reward_events_player_code",
                schema: "dbo",
                table: "offline_login_reward_events",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_offline_login_reward_events_promotion_id",
                schema: "dbo",
                table: "offline_login_reward_events",
                column: "promotion_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offline_login_reward_events",
                schema: "dbo");
        }
    }
}
