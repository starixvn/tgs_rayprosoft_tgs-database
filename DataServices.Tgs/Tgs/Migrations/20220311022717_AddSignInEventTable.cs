using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddSignInEventTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "sign_in_events",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "sign_in_events",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                date = table.Column<DateTime>(type: "date", nullable: false),
                player_code = table.Column<string>(type: "character varying(16)", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_sign_in_events", x => x.id);
                _ = table.ForeignKey(
                    name: "fk_sign_in_events_brands_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "fk_sign_in_events_players_brand_id",
                    column: x => x.player_code,
                    principalSchema: "dbo",
                    principalTable: "players",
                    principalColumn: "player_code",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_sign_in_events_brand_id",
            schema: "dbo",
            table: "sign_in_events",
            column: "brand_id");

        _ = migrationBuilder.CreateIndex(
            name: "ix_sign_in_events_player_code",
            schema: "dbo",
            table: "sign_in_events",
            column: "player_code");
    }
}
