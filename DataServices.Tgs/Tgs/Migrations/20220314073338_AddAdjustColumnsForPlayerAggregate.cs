using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAdjustColumnsForPlayerAggregate : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "agent_adjust_amount",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            name: "system_adjust_amount",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.RenameColumn(
            name: "company_adjust_amount",
            schema: "report",
            table: "player_aggregates",
            newName: "adjustment_amount");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.RenameColumn(
            name: "adjustment_amount",
            schema: "report",
            table: "player_aggregates",
            newName: "company_adjust_amount");

        _ = migrationBuilder.AddColumn<decimal>(
            name: "agent_adjust_amount",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "system_adjust_amount",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
