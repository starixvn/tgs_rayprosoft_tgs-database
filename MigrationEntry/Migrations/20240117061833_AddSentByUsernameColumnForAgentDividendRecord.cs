using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddSentByUsernameColumnForAgentDividendRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "negative_dividend_ids",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.AddColumn<string>(
                name: "sent_by_username",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sent_by_username",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.AddColumn<string[]>(
                name: "negative_dividend_ids",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }
    }
}
