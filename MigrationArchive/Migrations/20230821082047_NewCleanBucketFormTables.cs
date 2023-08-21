using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class NewCleanBucketFormTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_bucket_clean_event_source2",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    form_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_clean_event_source2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_clean_forms2",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cleaning_balance = table.Column<decimal>(type: "numeric", nullable: true),
                    cleaning_bucket_amounts = table.Column<string>(type: "jsonb", nullable: true),
                    clear_wagering_requirement_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    current_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    current_bucket_amounts = table.Column<string>(type: "jsonb", nullable: false),
                    deposit_form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_balance_return = table.Column<string>(type: "jsonb", nullable: true),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_clean_forms2", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_brands2",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_players2",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms2_brand_id",
                schema: "dbo",
                table: "player_bucket_clean_forms2",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms2_player_code",
                schema: "dbo",
                table: "player_bucket_clean_forms2",
                column: "player_code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_bucket_clean_event_source2",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bucket_clean_forms2",
                schema: "dbo");
        }
    }
}
