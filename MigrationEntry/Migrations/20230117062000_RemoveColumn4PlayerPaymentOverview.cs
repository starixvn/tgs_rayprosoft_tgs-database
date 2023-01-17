using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class RemoveColumn4PlayerPaymentOverview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fisrt_deposit_amount",
                schema: "dbo",
                table: "player_payment_overview");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "fisrt_deposit_amount",
                schema: "dbo",
                table: "player_payment_overview",
                type: "numeric",
                nullable: true);
        }
    }
}
