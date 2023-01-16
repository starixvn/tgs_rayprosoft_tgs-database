using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayerPaymentOverviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_payment_overview",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "text", nullable: false),
                    first_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    first_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    fisrt_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    recorded_by = table.Column<DateOnly>(type: "date", nullable: false),
                    total_deposit_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_payment_overview", x => x.player_code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_payment_overview",
                schema: "dbo");
        }
    }
}
