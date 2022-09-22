using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Update_Table_PlayerVipLevelAggregate : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<decimal>(
            name: "turnover",
            schema: "dbo",
            table: "player_vip_level_aggregates",
            type: "numeric",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "numeric(18,6)",
            oldPrecision: 18,
            oldScale: 6);

        _ = migrationBuilder.AlterColumn<decimal>(
            name: "deposit_amount",
            schema: "dbo",
            table: "player_vip_level_aggregates",
            type: "numeric",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "numeric(18,6)",
            oldPrecision: 18,
            oldScale: 6);
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<decimal>(
            name: "turnover",
            schema: "dbo",
            table: "player_vip_level_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "numeric");

        _ = migrationBuilder.AlterColumn<decimal>(
            name: "deposit_amount",
            schema: "dbo",
            table: "player_vip_level_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "numeric");
    }
}
