using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class AddPromotionMilestoneTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "promotion_milestones",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    milestone_level = table.Column<int>(type: "integer", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    promotion_distribute_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_milestones", x => x.id);
                    table.ForeignKey(
                        name: "fk_promotion_milestones_promotion_distributes_promotion_distri",
                        column: x => x.promotion_distribute_id,
                        principalSchema: "dbo",
                        principalTable: "promotion_distributes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_promotion_milestone_brand_id_promotion_id_player_code",
                schema: "dbo",
                table: "promotion_milestones",
                columns: new[] { "brand_id", "promotion_id", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_promotion_milestones_promotion_distribute_id",
                schema: "dbo",
                table: "promotion_milestones",
                column: "promotion_distribute_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "promotion_milestones",
                schema: "dbo");
        }
    }
}
