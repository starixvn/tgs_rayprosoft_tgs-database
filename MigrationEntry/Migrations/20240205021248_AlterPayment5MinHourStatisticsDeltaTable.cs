using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AlterPayment5MinHourStatisticsDeltaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "withdraw_handling_fee",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "withdraw_count",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "withdraw_amount",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "deposit_handling_fee",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "deposit_count",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "deposit_amount",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "withdraw_handling_fee",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "withdraw_count",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "withdraw_amount",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "deposit_handling_fee",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "deposit_count",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "deposit_amount",
                schema: "dbo",
                table: "five_minutes_payment_statistics_delta",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
