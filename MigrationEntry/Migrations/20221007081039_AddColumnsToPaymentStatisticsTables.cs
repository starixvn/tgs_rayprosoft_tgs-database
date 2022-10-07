using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddColumnsToPaymentStatisticsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "daily_deposit_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_withdraw_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "first_deposit_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "total_deposit_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "total_withdraw_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_deposit_amount",
                schema: "dbo",
                table: "brand_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_deposit_handling_fee",
                schema: "dbo",
                table: "brand_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_withdraw_amount",
                schema: "dbo",
                table: "brand_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_withdraw_handling_fee",
                schema: "dbo",
                table: "brand_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_deposit_amount",
                schema: "dbo",
                table: "agent_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_deposit_handling_fee",
                schema: "dbo",
                table: "agent_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_withdraw_amount",
                schema: "dbo",
                table: "agent_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "daily_withdraw_handling_fee",
                schema: "dbo",
                table: "agent_daily_payment_statistics",
                type: "numeric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "daily_deposit_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_withdraw_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "first_deposit_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "total_deposit_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "total_withdraw_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_deposit_amount",
                schema: "dbo",
                table: "brand_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_deposit_handling_fee",
                schema: "dbo",
                table: "brand_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_withdraw_amount",
                schema: "dbo",
                table: "brand_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_withdraw_handling_fee",
                schema: "dbo",
                table: "brand_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_deposit_amount",
                schema: "dbo",
                table: "agent_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_deposit_handling_fee",
                schema: "dbo",
                table: "agent_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_withdraw_amount",
                schema: "dbo",
                table: "agent_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "daily_withdraw_handling_fee",
                schema: "dbo",
                table: "agent_daily_payment_statistics");
        }
    }
}
