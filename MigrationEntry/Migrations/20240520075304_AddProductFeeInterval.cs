using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class AddProductFeeInterval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "virtual_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "previous_virtual_sports_percentage");

            migrationBuilder.RenameColumn(
                name: "sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "previous_sports_percentage");

            migrationBuilder.RenameColumn(
                name: "slot_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "previous_slot_percentage");

            migrationBuilder.RenameColumn(
                name: "lottery_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "previous_lottery_percentage");

            migrationBuilder.RenameColumn(
                name: "live_dealer_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "previous_live_dealer_percentage");

            migrationBuilder.RenameColumn(
                name: "card_game_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "previous_card_game_percentage");

            migrationBuilder.AddColumn<Guid>(
                name: "brand_id",
                schema: "dbo",
                table: "agent_product_fees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "current_card_game_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "current_live_dealer_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "current_lottery_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "current_slot_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "current_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "current_virtual_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "next_card_game_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "next_live_dealer_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "next_lottery_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "next_slot_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "next_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "next_virtual_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brand_id",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "current_card_game_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "current_live_dealer_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "current_lottery_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "current_slot_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "current_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "current_virtual_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "next_card_game_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "next_live_dealer_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "next_lottery_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "next_slot_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "next_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.DropColumn(
                name: "next_virtual_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees");

            migrationBuilder.RenameColumn(
                name: "previous_virtual_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "virtual_sports_percentage");

            migrationBuilder.RenameColumn(
                name: "previous_sports_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "sports_percentage");

            migrationBuilder.RenameColumn(
                name: "previous_slot_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "slot_percentage");

            migrationBuilder.RenameColumn(
                name: "previous_lottery_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "lottery_percentage");

            migrationBuilder.RenameColumn(
                name: "previous_live_dealer_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "live_dealer_percentage");

            migrationBuilder.RenameColumn(
                name: "previous_card_game_percentage",
                schema: "dbo",
                table: "agent_product_fees",
                newName: "card_game_percentage");
        }
    }
}
