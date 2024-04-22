using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddAgentDividendProductFeeTableAndAgentDividendPlatformChargeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "virtual_sports_rebate_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "virtual_sports_percentage");

            migrationBuilder.RenameColumn(
                name: "sports_rebate_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "sports_percentage");

            migrationBuilder.RenameColumn(
                name: "slot_rebate_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "slot_percentage");

            migrationBuilder.RenameColumn(
                name: "lottery_rebate_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "lottery_percentage");

            migrationBuilder.RenameColumn(
                name: "live_dealer_rebate_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "live_dealer_percentage");

            migrationBuilder.RenameColumn(
                name: "card_game_rebate_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "card_game_percentage");

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

            migrationBuilder.CreateTable(
                name: "agent_dividend_platform_charges",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_dividend_id = table.Column<int>(type: "integer", nullable: false),
                    percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_platform_charges_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_product_fees",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_dividend_id = table.Column<int>(type: "integer", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: false),
                    percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_product_fees_id", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_platform_charges_agent_dividend_id",
                schema: "dbo",
                table: "agent_dividend_platform_charges",
                column: "agent_dividend_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_product_fees_agent_dividend_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                column: "agent_dividend_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agent_dividend_platform_charges",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_product_fees",
                schema: "dbo");

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

            migrationBuilder.RenameColumn(
                name: "virtual_sports_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "virtual_sports_rebate_percentage");

            migrationBuilder.RenameColumn(
                name: "sports_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "sports_rebate_percentage");

            migrationBuilder.RenameColumn(
                name: "slot_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "slot_rebate_percentage");

            migrationBuilder.RenameColumn(
                name: "lottery_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "lottery_rebate_percentage");

            migrationBuilder.RenameColumn(
                name: "live_dealer_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "live_dealer_rebate_percentage");

            migrationBuilder.RenameColumn(
                name: "card_game_percentage",
                schema: "dbo",
                table: "brand_product_fees",
                newName: "card_game_rebate_percentage");
        }
    }
}
