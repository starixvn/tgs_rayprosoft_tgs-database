using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class PlayerBucketCleanFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_bucket_clean_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_anchor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cleaning_balance = table.Column<decimal>(type: "numeric", nullable: true),
                    cleaning_bucket_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    current_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    current_bucket_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    deposit_form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_clean_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_players",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms_brand_id",
                schema: "dbo",
                table: "player_bucket_clean_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms_player_code",
                schema: "dbo",
                table: "player_bucket_clean_forms",
                column: "player_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_bucket_clean_forms",
                schema: "dbo");
        }
    }
}
