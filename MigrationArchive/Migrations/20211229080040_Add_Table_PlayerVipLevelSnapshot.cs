using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Add_Table_PlayerVipLevelSnapshot : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "player_vip_level_snapshots",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "player_vip_level_snapshots",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                snapshot_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                data = table.Column<string>(type: "jsonb", nullable: false),
                created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_player_vip_level_snapshots", x => x.id);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_pk_player_vip_level_snapshots_player_code",
            schema: "dbo",
            table: "player_vip_level_snapshots",
            column: "brand_id");
    }
}
