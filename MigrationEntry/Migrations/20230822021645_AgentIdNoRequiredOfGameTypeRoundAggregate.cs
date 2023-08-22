using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AgentIdNoRequiredOfGameTypeRoundAggregate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_game_type_round_aggregate_id",
                schema: "report",
                table: "game_type_round_aggregates");

            migrationBuilder.AlterColumn<Guid>(
                name: "agent_id",
                schema: "report",
                table: "game_type_round_aggregates",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_game_type_round_aggregate_id",
                schema: "report",
                table: "game_type_round_aggregates",
                columns: new[] { "brand_id", "game_id", "player_code", "from", "to" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_game_type_round_aggregate_id",
                schema: "report",
                table: "game_type_round_aggregates");

            migrationBuilder.AlterColumn<Guid>(
                name: "agent_id",
                schema: "report",
                table: "game_type_round_aggregates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_game_type_round_aggregate_id",
                schema: "report",
                table: "game_type_round_aggregates",
                columns: new[] { "brand_id", "agent_id", "player_code", "from", "to" });
        }
    }
}
