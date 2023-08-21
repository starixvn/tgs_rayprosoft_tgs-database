using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddBrandPaymentAutoWithdrawTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand_payment_auto_withdraw",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_upper_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_payment_candidates = table.Column<string>(type: "jsonb", nullable: false),
                    enable_auto_withdraw = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    snapshot_event_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_auto_withdraw", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_payment_auto_withdraw_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_auto_withdraw_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_type_round_aggregates",
                schema: "report",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    to = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vip_level = table.Column<int>(type: "integer", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: false),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    original_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    round_count = table.Column<int>(type: "integer", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_type_round_aggregate_id", x => new { x.brand_id, x.agent_id, x.player_code, x.from, x.to });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_payment_auto_withdraw",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_auto_withdraw_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_type_round_aggregates",
                schema: "report");
        }
    }
}
