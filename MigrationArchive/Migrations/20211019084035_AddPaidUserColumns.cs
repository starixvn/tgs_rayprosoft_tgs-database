using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPaidUserColumns : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "paid_on",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "paid_user_id",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "paid_user_name",
            schema: "dbo",
            table: "withdraw_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<DateTimeOffset>(
            name: "paid_on",
            schema: "dbo",
            table: "withdraw_forms",
            type: "timestamp with time zone",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "paid_user_id",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "paid_user_name",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true);
    }
}
