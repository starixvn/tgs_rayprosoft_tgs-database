using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Drop_Table_PlayerVipLevelAdjustRecord_PlayerVipLevelBirthdayPromotion_PlayerVipLevelSeasonPromotion_PlayerVipLevelUpgradePromotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_vip_level_adjust_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_birthday_promotions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_season_promotions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_upgrade_promotions",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_vip_level_adjust_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    new_vip_id = table.Column<Guid>(type: "uuid", nullable: false),
                    old_vip_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    remark = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_adjust_records", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_birthday_promotions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    birthday = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    execute_year = table.Column<int>(type: "integer", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    player_vip_level_snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vip_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_birthday_promotions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_season_promotions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    from_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    player_vip_level_snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    season_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    to_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    vip_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_season_promotions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_upgrade_promotions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    player_vip_level_snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vip_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_upgrade_promotions", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_adjust_records_created_on",
                schema: "dbo",
                table: "player_vip_level_adjust_records",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_adjust_records_player_code",
                schema: "dbo",
                table: "player_vip_level_adjust_records",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_birthday_promotions_birthday",
                schema: "dbo",
                table: "player_vip_level_birthday_promotions",
                column: "birthday");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_birthday_promotions_player_code_execute_year",
                schema: "dbo",
                table: "player_vip_level_birthday_promotions",
                columns: new[] { "player_code", "execute_year" });

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_season_promotions_player_vip_level_snapshot_id",
                schema: "dbo",
                table: "player_vip_level_season_promotions",
                column: "player_vip_level_snapshot_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_season_promotions_vip_id",
                schema: "dbo",
                table: "player_vip_level_season_promotions",
                column: "vip_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_upgrade_promotions_player_vip_level_snapshot_id",
                schema: "dbo",
                table: "player_vip_level_upgrade_promotions",
                column: "player_vip_level_snapshot_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_upgrade_promotions_vip_id",
                schema: "dbo",
                table: "player_vip_level_upgrade_promotions",
                column: "vip_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_upgrade_promotions_vip_id_player_code",
                schema: "dbo",
                table: "player_vip_level_upgrade_promotions",
                columns: new[] { "vip_id", "player_code" });
        }
    }
}
