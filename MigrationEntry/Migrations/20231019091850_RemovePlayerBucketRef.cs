using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class RemovePlayerBucketRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_player_buckets_players_player_temp_id5",
                schema: "dbo",
                table: "player_buckets");

            migrationBuilder.DropIndex(
                name: "ix_player_buckets_player_code1",
                schema: "dbo",
                table: "player_buckets");

            migrationBuilder.DropColumn(
                name: "player_code1",
                schema: "dbo",
                table: "player_buckets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "player_code1",
                schema: "dbo",
                table: "player_buckets",
                type: "character varying(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_buckets_player_code1",
                schema: "dbo",
                table: "player_buckets",
                column: "player_code1");

            migrationBuilder.AddForeignKey(
                name: "fk_player_buckets_players_player_temp_id5",
                schema: "dbo",
                table: "player_buckets",
                column: "player_code1",
                principalSchema: "dbo",
                principalTable: "players",
                principalColumn: "player_code");
        }
    }
}
