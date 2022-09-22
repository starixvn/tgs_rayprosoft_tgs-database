using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateBrandMaintenaceTimeColumnType : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "end_time",
            schema: "dbo",
            table: "brand_maintenance",
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(TimeOnly),
            oldType: "time without time zone");

        _ = migrationBuilder.AlterColumn<DateTimeOffset>(
            name: "begin_time",
            schema: "dbo",
            table: "brand_maintenance",
            type: "timestamp with time zone",
            nullable: false,
            oldClrType: typeof(TimeOnly),
            oldType: "time without time zone");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<TimeOnly>(
            name: "end_time",
            schema: "dbo",
            table: "brand_maintenance",
            type: "time without time zone",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");

        _ = migrationBuilder.AlterColumn<TimeOnly>(
            name: "begin_time",
            schema: "dbo",
            table: "brand_maintenance",
            type: "time without time zone",
            nullable: false,
            oldClrType: typeof(DateTimeOffset),
            oldType: "timestamp with time zone");
    }
}
