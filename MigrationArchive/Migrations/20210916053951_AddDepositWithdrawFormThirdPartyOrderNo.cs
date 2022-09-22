using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddDepositWithdrawFormThirdPartyOrderNo : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "third_party_order_no",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "third_party_order_no",
            schema: "dbo",
            table: "deposit_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "third_party_order_no",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "third_party_order_no",
            schema: "dbo",
            table: "deposit_forms",
            type: "text",
            nullable: true);
    }
}
