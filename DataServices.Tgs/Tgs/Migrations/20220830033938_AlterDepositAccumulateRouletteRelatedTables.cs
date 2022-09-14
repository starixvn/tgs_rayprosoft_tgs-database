using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AlterDepositAccumulateRouletteRelatedTables : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropPrimaryKey(
            name: "pk_deposit_accumulate_roulette_events",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events");

        _ = migrationBuilder.DropColumn(
            name: "date",
            schema: "dbo",
            table: "deposit_accumulate_roulette_game_events");

        _ = migrationBuilder.AddColumn<Guid>(
            name: "deposit_accumulate_roulette_event_id",
            schema: "dbo",
            table: "deposit_accumulate_roulette_game_events",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        _ = migrationBuilder.AddColumn<Guid>(
            name: "id",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        _ = migrationBuilder.AddPrimaryKey(
            name: "pk_deposit_accumulate_roulette_events",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events",
            column: "id");

        _ = migrationBuilder.CreateIndex(
            name: "ix_deposit_accumulate_roulette_events_player_code",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events",
            column: "player_code");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropPrimaryKey(
            name: "pk_deposit_accumulate_roulette_events",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events");

        _ = migrationBuilder.DropIndex(
            name: "ix_deposit_accumulate_roulette_events_player_code",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events");

        _ = migrationBuilder.DropColumn(
            name: "deposit_accumulate_roulette_event_id",
            schema: "dbo",
            table: "deposit_accumulate_roulette_game_events");

        _ = migrationBuilder.DropColumn(
            name: "id",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events");

        _ = migrationBuilder.AddColumn<DateOnly>(
            name: "date",
            schema: "dbo",
            table: "deposit_accumulate_roulette_game_events",
            type: "date",
            nullable: false,
            defaultValue: new DateOnly(1, 1, 1));

        _ = migrationBuilder.AddPrimaryKey(
            name: "pk_deposit_accumulate_roulette_events",
            schema: "dbo",
            table: "deposit_accumulate_roulette_events",
            columns: new[] { "player_code", "promotion_id", "date" });
    }
}
