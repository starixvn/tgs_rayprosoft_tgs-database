using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Delete_Index_ix_game_wager_stat_brand_h_c_brand_id_game_provider_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_brand_h_c_brand_id_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_stat_brand_h_c_d_brand_id_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_c_brand_id_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                columns: new[] { "stat_on", "brand_id", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_brand_h_c_d_brand_id_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_brand_hour_closes",
                columns: new[] { "stat_day_on", "brand_id", "game_provider_id" });
        }
    }
}
