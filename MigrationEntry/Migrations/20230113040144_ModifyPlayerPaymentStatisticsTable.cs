using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class ModifyPlayerPaymentStatisticsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "first_withdraw_amount",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "first_withdraw_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "first_withdraw_on",
                schema: "dbo",
                table: "player_daily_payment_statistics",
                type: "timestamptz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "first_withdraw_amount",
                schema: "dbo",
                table: "player_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "first_withdraw_handling_fee",
                schema: "dbo",
                table: "player_daily_payment_statistics");

            migrationBuilder.DropColumn(
                name: "first_withdraw_on",
                schema: "dbo",
                table: "player_daily_payment_statistics");
        }
    }
}
