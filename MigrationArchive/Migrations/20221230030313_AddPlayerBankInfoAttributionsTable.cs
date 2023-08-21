using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPlayerBankInfoAttributionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_bankinfo_attributions",
                schema: "dbo",
                columns: table => new
                {
                    bank_info_hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bankinfo_attributions", x => new { x.brand_id, x.bank_info_hash });
                    table.ForeignKey(
                        name: "fk_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_bankinfo_attributions_player_code",
                schema: "dbo",
                table: "player_bankinfo_attributions",
                column: "player_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_bankinfo_attributions",
                schema: "dbo");
        }
    }
}
