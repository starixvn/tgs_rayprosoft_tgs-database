using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPayment5MinHourStatisticsTables : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "five_minutes_payment_statistics",
            schema: "dbo",
            columns: table => new
            {
                user_id = table.Column<string>(type: "text", nullable: false),
                user_type = table.Column<int>(type: "integer", nullable: false),
                time_point = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                deposit_count = table.Column<int>(type: "integer", nullable: true),
                withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                withdraw_count = table.Column<int>(type: "integer", nullable: true),
                first_deposit_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                first_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                first_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                first_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                first_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                first_withdraw_on = table.Column<DateTime>(type: "timestamptz", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_five_minutes_payment_statistics", x => new { x.time_point, x.user_id, x.user_type });
            });

        migrationBuilder.CreateTable(
            name: "hour_payment_statistics",
            schema: "dbo",
            columns: table => new
            {
                user_id = table.Column<string>(type: "text", nullable: false),
                user_type = table.Column<int>(type: "integer", nullable: false),
                time_point = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                deposit_count = table.Column<int>(type: "integer", nullable: true),
                withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                withdraw_count = table.Column<int>(type: "integer", nullable: true),
                first_deposit_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                first_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                first_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                first_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                first_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                first_withdraw_on = table.Column<DateTime>(type: "timestamptz", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_hour_payment_statistics", x => new { x.time_point, x.user_id, x.user_type });
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "five_minutes_payment_statistics",
            schema: "dbo");

        migrationBuilder.DropTable(
            name: "hour_payment_statistics",
            schema: "dbo");
    }
}
