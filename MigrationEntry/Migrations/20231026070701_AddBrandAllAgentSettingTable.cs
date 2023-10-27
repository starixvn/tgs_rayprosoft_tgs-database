using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddBrandAllAgentSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "player_all_agent_settlement_interval_type",
                schema: "dbo",
                table: "brands");

            migrationBuilder.CreateTable(
                name: "brand_all_agent_settings",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    @switch = table.Column<bool>(name: "switch", type: "boolean", nullable: false),
                    settlement_interval_type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_all_agent_settings", x => x.brand_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_all_agent_settings",
                schema: "dbo");

            migrationBuilder.AddColumn<short>(
                name: "player_all_agent_settlement_interval_type",
                schema: "dbo",
                table: "brands",
                type: "smallint",
                nullable: false,
                defaultValue: (short)3);
        }
    }
}
