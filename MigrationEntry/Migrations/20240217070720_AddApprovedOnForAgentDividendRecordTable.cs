using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddApprovedOnForAgentDividendRecordTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sent_on",
                schema: "dbo",
                table: "agent_dividend_records",
                newName: "approved_on");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_on",
                schema: "dbo",
                table: "agent_dividend_records",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "dbo",
                table: "agent_dividend_records");

            migrationBuilder.RenameColumn(
                name: "approved_on",
                schema: "dbo",
                table: "agent_dividend_records",
                newName: "sent_on");
        }
    }
}
