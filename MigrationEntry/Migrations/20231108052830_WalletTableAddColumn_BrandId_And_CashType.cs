using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class WalletTableAddColumn_BrandId_And_CashType : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "brand_id",
            schema: "dbo",
            table: "wallets",
            type: "uuid",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            name: "cash_type",
            schema: "dbo",
            table: "wallets",
            type: "text",
            nullable: false,
            defaultValue: "Player");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "brand_id",
            schema: "dbo",
            table: "wallets");

        migrationBuilder.DropColumn(
            name: "cash_type",
            schema: "dbo",
            table: "wallets");
    }
}
