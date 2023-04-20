using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddTableStationLetter2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "station_letter2",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    come_from = table.Column<Guid>(type: "uuid", nullable: true),
                    content = table.Column<string>(type: "text", nullable: false),
                    have_read = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    quotation = table.Column<string>(type: "text", nullable: true),
                    received_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    receiver = table.Column<string>(type: "text", nullable: false),
                    replied = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    sender = table.Column<string>(type: "text", nullable: false),
                    sent_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_station_letter2", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "station_letter2",
                schema: "dbo");
        }
    }
}
