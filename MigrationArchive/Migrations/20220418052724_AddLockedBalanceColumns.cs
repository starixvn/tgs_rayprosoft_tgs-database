using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using Tgs.Migrations;
using TGS.Core.DataServices.Base.Extensions;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddLockedBalanceColumns : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "locked_balance",
            schema: "dbo",
            table: "wallets");

        _ = migrationBuilder.DropColumn(
            name: "locked_balance",
            schema: "dbo",
            table: "transactions");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "locked_balance",
            schema: "dbo",
            table: "wallets",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "locked_balance",
            schema: "dbo",
            table: "transactions",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        migrationBuilder.SqlResource(
            Assembly.GetExecutingAssembly(),
            string.Format(MigrationConsts._FunctionSqlFormat, "wallet_update_wallet_balance"));
    }
}
