using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddBrandContractIdAndPlatformCharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "active_number",
                schema: "dbo",
                table: "agent_dividends",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "platform_charge_percentage",
                schema: "dbo",
                table: "agent_dividends",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "default_brand_contract_id",
                schema: "dbo",
                table: "agent_dividend_contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active_number",
                schema: "dbo",
                table: "agent_dividends");

            migrationBuilder.DropColumn(
                name: "platform_charge_percentage",
                schema: "dbo",
                table: "agent_dividends");

            migrationBuilder.DropColumn(
                name: "default_brand_contract_id",
                schema: "dbo",
                table: "agent_dividend_contracts");
        }
    }
}
