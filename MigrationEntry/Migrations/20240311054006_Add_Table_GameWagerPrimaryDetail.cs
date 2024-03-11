using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_GameWagerPrimaryDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_primaries",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "pk_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_created_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropPrimaryKey(
                name: "pk_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropColumn(
                name: "cancel_state",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropColumn(
                name: "closed_state",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropColumn(
                name: "void_state",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropColumn(
                name: "cancel_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropColumn(
                name: "closed_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropColumn(
                name: "void_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "external_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone",
                comment: "三方下注/創建時間",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldComment: "三方下注/創建時間");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                comment: "修改時間");

            migrationBuilder.AddPrimaryKey(
                name: "pk_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "id" });

            migrationBuilder.CreateTable(
                name: "game_wager_primary_details",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "創建時間"),
                    game_wager_primary_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲投注主要識別碼"),
                    game_wager_primary_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "附加數據"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_primary_details", x => new { x.created_on, x.id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements",
                column: "game_wager_primary_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on",
                schema: "dbo",
                table: "game_wager_settlements",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_external_created_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "external_created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "wager_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                column: "game_wager_primary_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                column: "first_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_resettle_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "external_resettle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "updated_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_firsts_f_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "wager_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primary_details",
                schema: "dbo",
                table: "game_wager_primary_details",
                column: "game_wager_primary_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_primary_details",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "pk_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_c_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_c_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_c_on_external_created_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_c_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropPrimaryKey(
                name: "pk_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_external_resettle_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_firsts_f_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropColumn(
                name: "updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.AddColumn<int>(
                name: "cancel_state",
                schema: "dbo",
                table: "game_wager_settlements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "取消狀態");

            migrationBuilder.AddColumn<int>(
                name: "closed_state",
                schema: "dbo",
                table: "game_wager_settlements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "關閉狀態");

            migrationBuilder.AddColumn<int>(
                name: "void_state",
                schema: "dbo",
                table: "game_wager_settlements",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "作廢狀態");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "external_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                type: "timestamp with time zone",
                nullable: false,
                comment: "三方下注/創建時間",
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone",
                oldComment: "三方下注/創建時間");

            migrationBuilder.AddColumn<int>(
                name: "cancel_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "取消狀態");

            migrationBuilder.AddColumn<int>(
                name: "closed_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "關閉狀態");

            migrationBuilder.AddColumn<int>(
                name: "void_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "作廢狀態");

            migrationBuilder.AddPrimaryKey(
                name: "pk_game_wager_settlements",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "game_wager_primary_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_game_wager_settlement_firsts",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "game_wager_primary_id" });

            migrationBuilder.CreateTable(
                name: "game_wager_primaries",
                schema: "dbo",
                columns: table => new
                {
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_wager_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_primaries", x => new { x.external_created_on, x.game_provider_id, x.game_id, x.wallet_id, x.external_wager_id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on",
                schema: "dbo",
                table: "game_wager_settlements",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_created_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "wager_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_created_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_external_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_external_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "wager_state" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "game_provider_id", "game_id", "wallet_id", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on",
                schema: "dbo",
                table: "game_wager_primaries",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_brand_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_brand_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_external_round_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_external_wager_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_game_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_licensee_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_player_code",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_c_on_reseller_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "created_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_external_round_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_external_wager_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "external_wager_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_game_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_game_provider_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_licensee_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_player_code",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_primaries_e_c_on_reseller_id",
                schema: "dbo",
                table: "game_wager_primaries",
                columns: new[] { "external_created_on", "reseller_id" });
        }
    }
}
