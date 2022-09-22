using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddDepositWithdrawFormReviewedIdNameTime : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "reviewed_on",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "reviewed_user_id",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "reviewed_user_name",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "reviewed_on",
            schema: "dbo",
            table: "deposit_forms");

        _ = migrationBuilder.DropColumn(
            name: "reviewed_user_id",
            schema: "dbo",
            table: "deposit_forms");

        _ = migrationBuilder.DropColumn(
            name: "reviewed_user_name",
            schema: "dbo",
            table: "deposit_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<DateTimeOffset>(
            name: "reviewed_on",
            schema: "dbo",
            table: "withdraw_forms",
            type: "timestamp with time zone",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "reviewed_user_id",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "reviewed_user_name",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<DateTimeOffset>(
            name: "reviewed_on",
            schema: "dbo",
            table: "deposit_forms",
            type: "timestamp with time zone",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "reviewed_user_id",
            schema: "dbo",
            table: "deposit_forms",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "reviewed_user_name",
            schema: "dbo",
            table: "deposit_forms",
            type: "text",
            nullable: true);
    }
}
