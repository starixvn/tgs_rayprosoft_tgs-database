using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AdjustAgentDividendRelateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "enable_player_agent",
                schema: "dbo",
                table: "brands",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "negative_agent_dividend_carry_forward",
                schema: "dbo",
                table: "agents",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "negative_agent_dividend_carry_forward",
                schema: "dbo",
                table: "agent_dividends",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "actual_agent_dividend_amount",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "negative_agent_dividend_amount",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "negative_agent_dividend_carry_forward",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "remark",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "status",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_records_brand_id_agent_id",
                schema: "dbo",
                table: "agent_dividend_records",
                columns: new[] { "brand_id", "agent_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_agent_dividend_records_brand_id_agent_id",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.DropColumn(
                name: "enable_player_agent",
                schema: "dbo",
                table: "brands");

            migrationBuilder.DropColumn(
                name: "negative_agent_dividend_carry_forward",
                schema: "dbo",
                table: "agents");

            migrationBuilder.DropColumn(
                name: "negative_agent_dividend_carry_forward",
                schema: "dbo",
                table: "agent_dividends");

            migrationBuilder.DropColumn(
                name: "actual_agent_dividend_amount",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.DropColumn(
                name: "negative_agent_dividend_amount",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.DropColumn(
                name: "negative_agent_dividend_carry_forward",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.DropColumn(
                name: "remark",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.DropColumn(
                name: "status",
                schema: "dbo",
                table: "agent_dividend_records");
        }
    }
}
