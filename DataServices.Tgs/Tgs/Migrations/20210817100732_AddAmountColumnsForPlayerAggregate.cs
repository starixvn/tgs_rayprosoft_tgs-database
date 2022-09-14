using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddAmountColumnsForPlayerAggregate : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            "dividend_amount",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropColumn(
            "promotion_amount",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.RenameColumn(
            "rebate_amount",
            schema: "report",
            table: "player_aggregates",
            newName: "net_profit");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            "net_profit",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.AddColumn<decimal>(
            "rebate_amount",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            "dividend_amount",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            "promotion_amount",
            schema: "report",
            table: "player_aggregates",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
