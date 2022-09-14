using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPlayerBirthRemark : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "birthday",
            schema: "dbo",
            table: "players");

        _ = migrationBuilder.DropColumn(
            name: "remark",
            schema: "dbo",
            table: "players");

        _ = migrationBuilder.AlterColumn<int>(
            name: "game_type",
            schema: "report",
            table: "brand_game_provider_aggregates",
            type: "integer",
            nullable: false,
            oldClrType: typeof(short),
            oldType: "smallint");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<DateTimeOffset>(
            name: "birthday",
            schema: "dbo",
            table: "players",
            type: "timestamp with time zone",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "remark",
            schema: "dbo",
            table: "players",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AlterColumn<short>(
            name: "game_type",
            schema: "report",
            table: "brand_game_provider_aggregates",
            type: "smallint",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "integer");
    }
}
