using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Delete_Field_stat_day_on : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_player_h_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_player_h_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_player_h_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_player_h_c_d_player_code",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_player_h_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_player_h_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_brand_h_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_brand_h_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_brand_h_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_brand_h_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_brand_h_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");

            migrationBuilder.DropColumn(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes");

            migrationBuilder.DropColumn(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                comment: "統計日期時間");

            migrationBuilder.AddColumn<DateOnly>(
                name: "stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                comment: "統計日期時間");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_player_h_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                columns: new[] { "stat_day_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_player_h_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                columns: new[] { "stat_day_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_player_h_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                columns: new[] { "stat_day_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_player_h_c_d_player_code",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                columns: new[] { "stat_day_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_player_h_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                columns: new[] { "stat_day_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_player_h_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_player_hour_closes",
                column: "stat_day_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                columns: new[] { "stat_day_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                columns: new[] { "stat_day_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                columns: new[] { "stat_day_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                columns: new[] { "stat_day_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                column: "stat_day_on");
        }
    }
}
