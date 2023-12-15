using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AdjustPromotionDistrubuteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_promotion_distribute_plans_promotions",
                schema: "dbo",
                table: "promotion_distribute_plans");

            migrationBuilder.DropForeignKey(
                name: "fk_promotion_distributes_promotions",
                schema: "dbo",
                table: "promotion_distributes");

            migrationBuilder.DropIndex(
                name: "ix_promotion_distributes_promotion_id",
                schema: "dbo",
                table: "promotion_distributes");

            migrationBuilder.DropIndex(
                name: "ix_promotion_distribute_plans_promotion_id",
                schema: "dbo",
                table: "promotion_distribute_plans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_promotion_distributes_promotion_id",
                schema: "dbo",
                table: "promotion_distributes",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_distribute_plans_promotion_id",
                schema: "dbo",
                table: "promotion_distribute_plans",
                column: "promotion_id");

            migrationBuilder.AddForeignKey(
                name: "fk_promotion_distribute_plans_promotions",
                schema: "dbo",
                table: "promotion_distribute_plans",
                column: "promotion_id",
                principalSchema: "dbo",
                principalTable: "promotions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_promotion_distributes_promotions",
                schema: "dbo",
                table: "promotion_distributes",
                column: "promotion_id",
                principalSchema: "dbo",
                principalTable: "promotions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
