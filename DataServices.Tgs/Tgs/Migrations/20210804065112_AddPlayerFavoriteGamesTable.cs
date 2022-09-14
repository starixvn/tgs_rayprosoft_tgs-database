using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPlayerFavoriteGamesTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "player_favorite_games",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "player_favorite_games",
            schema: "dbo",
            columns: table => new
            {
                game_id = table.Column<int>(type: "integer", nullable: false),
                player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                game_type = table.Column<int>(type: "integer", nullable: false),
                sub_game_provider_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_player_favorite_games", x => new { x.player_code, x.game_id });
                _ = table.ForeignKey(
                    name: "fk_player_favorite_games_brand_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "fk_player_favorite_games_player_player_code",
                    column: x => x.player_code,
                    principalSchema: "dbo",
                    principalTable: "players",
                    principalColumn: "player_code",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_favorite_games_brand_id",
            schema: "dbo",
            table: "player_favorite_games",
            column: "brand_id",
            unique: true);

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_favorite_games_player_code",
            schema: "dbo",
            table: "player_favorite_games",
            column: "player_code",
            unique: true);
    }
}
