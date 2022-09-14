using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class HandlingFeeChangeDateTimeType : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<DateTime>(
            name: "created_on",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "timestamp without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamptz");

        _ = migrationBuilder.AlterColumn<DateTime>(
            name: "approved_on",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "timestamp without time zone",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamptz");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<DateTime>(
            name: "created_on",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "timestamptz",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp without time zone");

        _ = migrationBuilder.AlterColumn<DateTime>(
            name: "approved_on",
            schema: "dbo",
            table: "payment_handling_fees",
            type: "timestamptz",
            nullable: false,
            oldClrType: typeof(DateTime),
            oldType: "timestamp without time zone");
    }
}
