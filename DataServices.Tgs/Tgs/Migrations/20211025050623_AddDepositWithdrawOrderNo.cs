using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddDepositWithdrawOrderNo : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "order_no",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "order_no",
            schema: "dbo",
            table: "deposit_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "order_no",
            schema: "dbo",
            table: "withdraw_forms",
            type: "character varying(50)",
            maxLength: 50,
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "order_no",
            schema: "dbo",
            table: "deposit_forms",
            type: "character varying(50)",
            maxLength: 50,
            nullable: true);
    }
}
