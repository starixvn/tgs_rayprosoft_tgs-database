using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RemovePlayerAggregateTableColumns : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<int>(
            name: "active_player",
            schema: "report",
            table: "player_aggregates",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        _ = migrationBuilder.AddColumn<int>(
            name: "deposit_count",
            schema: "report",
            table: "player_aggregates",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        _ = migrationBuilder.AddColumn<int>(
            name: "login_player",
            schema: "report",
            table: "player_aggregates",
            type: "integer",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "active_player",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "deposit_count",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "login_player",
            schema: "report",
            table: "player_aggregates");
    }
}
