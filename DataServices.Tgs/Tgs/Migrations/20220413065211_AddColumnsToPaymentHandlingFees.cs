using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddColumnsToPaymentHandlingFees : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "approved_on",
            schema: "dbo",
            table: "payment_handling_fees");

        _ = migrationBuilder.DropColumn(
            name: "created_on",
            schema: "dbo",
            table: "payment_handling_fees");

        _ = migrationBuilder.DropColumn(
            name: "user_id",
            schema: "dbo",
            table: "payment_handling_fees");

        _ = migrationBuilder.DropColumn(
            name: "user_type",
            schema: "dbo",
            table: "payment_handling_fees");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<DateTime>(
            name: "approved_on",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "timestamp without time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        _ = migrationBuilder.AddColumn<DateTime>(
            name: "created_on",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "timestamp without time zone",
            nullable: false,
            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        _ = migrationBuilder.AddColumn<string>(
            name: "user_id",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "text",
            nullable: false,
            defaultValue: "");

        _ = migrationBuilder.AddColumn<int>(
            name: "user_type",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "integer",
            nullable: false,
            defaultValue: 0);
    }
}
