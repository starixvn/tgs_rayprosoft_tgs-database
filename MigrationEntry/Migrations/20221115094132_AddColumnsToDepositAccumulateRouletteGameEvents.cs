using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddColumnsToDepositAccumulateRouletteGameEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "bucket",
                schema: "dbo",
                table: "deposit_accumulate_roulette_game_events",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "roulette_count",
                schema: "dbo",
                table: "deposit_accumulate_roulette_game_events",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bucket",
                schema: "dbo",
                table: "deposit_accumulate_roulette_game_events");

            migrationBuilder.DropColumn(
                name: "roulette_count",
                schema: "dbo",
                table: "deposit_accumulate_roulette_game_events");
        }
    }
}
