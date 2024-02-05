using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPayment5MinHourStatisticsDeltaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "five_minutes_payment_statistics_delta",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    time_point = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    deposit_count = table.Column<int>(type: "integer", nullable: true),
                    withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    withdraw_count = table.Column<int>(type: "integer", nullable: true),
                    deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_five_minutes_payment_statistics_delta", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "five_minutes_payment_statistics_delta",
                schema: "dbo");
        }
    }
}
