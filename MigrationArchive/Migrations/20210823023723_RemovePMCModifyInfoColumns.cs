using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RemovePMCModifyInfoColumns : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "created_by_username",
            schema: "dbo",
            table: "payment_method_channels",
            type: "character varying(32)",
            maxLength: 32,
            nullable: false,
            defaultValue: "");

        _ = migrationBuilder.AddColumn<DateTimeOffset>(
            name: "created_on",
            schema: "dbo",
            table: "payment_method_channels",
            type: "timestamp with time zone",
            nullable: false,
            defaultValueSql: "Now()");

        _ = migrationBuilder.AddColumn<string>(
            name: "updated_by_username",
            schema: "dbo",
            table: "payment_method_channels",
            type: "character varying(32)",
            maxLength: 32,
            nullable: false,
            defaultValue: "");

        _ = migrationBuilder.AddColumn<DateTimeOffset>(
            name: "updated_on",
            schema: "dbo",
            table: "payment_method_channels",
            type: "timestamp with time zone",
            nullable: false,
            defaultValueSql: "Now()");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "created_by_username",
            schema: "dbo",
            table: "payment_method_channels");

        _ = migrationBuilder.DropColumn(
            name: "created_on",
            schema: "dbo",
            table: "payment_method_channels");

        _ = migrationBuilder.DropColumn(
            name: "updated_by_username",
            schema: "dbo",
            table: "payment_method_channels");

        _ = migrationBuilder.DropColumn(
            name: "updated_on",
            schema: "dbo",
            table: "payment_method_channels");
    }
}
