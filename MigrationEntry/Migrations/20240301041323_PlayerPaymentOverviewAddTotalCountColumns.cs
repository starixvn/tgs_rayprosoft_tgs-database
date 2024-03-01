using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class PlayerPaymentOverviewAddTotalCountColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total_deposit_count",
                schema: "dbo",
                table: "player_payment_overview",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_withdraw_count",
                schema: "dbo",
                table: "player_payment_overview",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_deposit_count",
                schema: "dbo",
                table: "player_payment_overview");

            migrationBuilder.DropColumn(
                name: "total_withdraw_count",
                schema: "dbo",
                table: "player_payment_overview");
        }
    }
}
