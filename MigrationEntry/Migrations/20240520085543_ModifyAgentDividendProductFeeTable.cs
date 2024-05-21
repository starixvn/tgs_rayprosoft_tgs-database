using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class ModifyAgentDividendProductFeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "game_type",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.RenameColumn(
                name: "win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                newName: "virtual_sports_win_loss_amount");

            migrationBuilder.RenameColumn(
                name: "percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                newName: "virtual_sports_percentage");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                newName: "brand_id");

            migrationBuilder.AddColumn<Guid>(
                name: "agent_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "card_game_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "card_game_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "from",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "live_dealer_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "live_dealer_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "lottery_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "lottery_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "slot_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "slot_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "sports_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "sports_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "to",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                column: "agent_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "agent_id",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "card_game_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "card_game_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "from",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "live_dealer_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "live_dealer_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "lottery_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "lottery_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "slot_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "slot_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "sports_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "sports_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.DropColumn(
                name: "to",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.RenameColumn(
                name: "virtual_sports_win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                newName: "win_loss_amount");

            migrationBuilder.RenameColumn(
                name: "virtual_sports_percentage",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                newName: "percentage");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                newName: "id");

            migrationBuilder.AddColumn<short>(
                name: "game_type",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                column: "id");
        }
    }
}
