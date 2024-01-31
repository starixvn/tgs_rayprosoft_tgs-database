using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Drop_Tabe_PlayerVipLevelUpgradeRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_vip_level_upgrade_records",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_vip_level_upgrade_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    execution_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    player_vip_level_snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_upgrade_records", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_upgrade_records_brand_id",
                schema: "dbo",
                table: "player_vip_level_upgrade_records",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_upgrade_records_player_vip_level_snapshot_id",
                schema: "dbo",
                table: "player_vip_level_upgrade_records",
                column: "player_vip_level_snapshot_id");
        }
    }
}
