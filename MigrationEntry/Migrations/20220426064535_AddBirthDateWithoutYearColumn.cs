using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBirthDateWithoutYearColumn : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "birthdate",
            schema: "dbo",
            table: "players");

        _ = migrationBuilder.AlterColumn<DateOnly>(
            name: "birthday",
            schema: "dbo",
            table: "players",
            type: "Date",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(4)",
            oldMaxLength: 4,
            oldNullable: true,
            oldComputedColumnSql: "lpad(extract('month' from birthdate)::text,2,'0') || lpad(extract('day' from birthdate)::text,2,'0')");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<DateOnly>(
            name: "birthdate",
            schema: "dbo",
            table: "players",
            type: "Date",
            nullable: true);

        _ = migrationBuilder.AlterColumn<string>(
            name: "birthday",
            schema: "dbo",
            table: "players",
            type: "character varying(4)",
            maxLength: 4,
            nullable: true,
            computedColumnSql: "lpad(extract('month' from birthdate)::text,2,'0') || lpad(extract('day' from birthdate)::text,2,'0')",
            stored: true,
            oldClrType: typeof(DateOnly),
            oldType: "Date",
            oldNullable: true);
    }
}
