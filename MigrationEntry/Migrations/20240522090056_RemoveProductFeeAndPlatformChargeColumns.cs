using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProductFeeAndPlatformChargeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "platform_charge_percentage",
                schema: "report",
                table: "player_game_rebate_aggregates");

            migrationBuilder.DropColumn(
                name: "product_fee_percentage",
                schema: "report",
                table: "player_game_rebate_aggregates");

            migrationBuilder.DropColumn(
                name: "platform_charge_percentage",
                schema: "report",
                table: "player_aggregates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "platform_charge_percentage",
                schema: "report",
                table: "player_game_rebate_aggregates",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "product_fee_percentage",
                schema: "report",
                table: "player_game_rebate_aggregates",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "platform_charge_percentage",
                schema: "report",
                table: "player_aggregates",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
