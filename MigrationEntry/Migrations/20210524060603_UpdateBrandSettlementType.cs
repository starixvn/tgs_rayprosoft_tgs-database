using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateBrandSettlementType : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<int>(
            name: "settlement_interval_type",
            schema: "dbo",
            table: "brands",
            type: "integer",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "integer",
            oldNullable: true);

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "previous_settlement_to",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone",
            oldNullable: true);

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "previous_settlement_from",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone",
            oldNullable: true);

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "next_settlement_to",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone",
            oldNullable: true);

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "next_settlement_from",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone",
            oldNullable: true);

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "current_settlement_to",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone",
            oldNullable: true);

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "current_settlement_from",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: false,
            defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone",
            oldNullable: true);
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<int>(
            name: "settlement_interval_type",
            schema: "dbo",
            table: "brands",
            type: "integer",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "integer");

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "previous_settlement_to",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "previous_settlement_from",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "next_settlement_to",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "next_settlement_from",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "current_settlement_to",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "current_settlement_from",
            schema: "dbo",
            table: "brands",
            type: "timestamp with time zone",
            nullable: true,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");
    }
}
