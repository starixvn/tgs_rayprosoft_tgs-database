using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddDistributeRegisterEventTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "distribute_register_events",
            schema: "dbo");

        _ = migrationBuilder.DropColumn(
            name: "bonus",
            schema: "dbo",
            table: "roulette_sign_in_events");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "bonus",
            schema: "dbo",
            table: "roulette_sign_in_events",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.CreateTable(
            name: "distribute_register_events",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_distribute_register_events", x => x.id);
                _ = table.ForeignKey(
                    name: "fk_distribute_register_events_brands_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "fk_distribute_register_events_players_brand_id",
                    column: x => x.player_code,
                    principalSchema: "dbo",
                    principalTable: "players",
                    principalColumn: "player_code",
                    onDelete: ReferentialAction.Cascade);
                _ = table.ForeignKey(
                    name: "fk_distribute_register_events_promotions_promotion_id",
                    column: x => x.promotion_id,
                    principalSchema: "dbo",
                    principalTable: "promotions",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_distribute_register_events_brand_id",
            schema: "dbo",
            table: "distribute_register_events",
            column: "brand_id");

        _ = migrationBuilder.CreateIndex(
            name: "ix_distribute_register_events_player_code",
            schema: "dbo",
            table: "distribute_register_events",
            column: "player_code");

        _ = migrationBuilder.CreateIndex(
            name: "ix_distribute_register_events_promotion_id",
            schema: "dbo",
            table: "distribute_register_events",
            column: "promotion_id");
    }
}
