using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Drop_Table_GamePlayerTransformIdnLive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_player_transform_idnlive",
                schema: "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_player_transform_idnlive",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10000001', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    configuration = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    player_code = table.Column<string>(type: "character varying", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_player_transform_idnlive", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_player_transform_idnlive_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_player_transform_idnlive_player_code",
                schema: "dbo",
                table: "game_player_transform_idnlive",
                column: "player_code",
                unique: true);
        }
    }
}
