using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class PlayerAllAgentRebateContributor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_all_agent_rebate_contributors",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    child_player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    sports_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_all_agent_rebates_contributor_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_all_agent_rebate_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    all_agent_game_type = table.Column<short>(type: "smallint", nullable: false),
                    all_agent_rebate_type = table.Column<short>(type: "smallint", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    condition_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    actual_player_number = table.Column<int>(type: "integer", nullable: false),
                    actual_condition_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_all_agent_rebate_records_id", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebate_contributors_from_to_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                columns: new[] { "from", "to", "player_code", "child_player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebate_records_brand_id_report_date_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                columns: new[] { "brand_id", "from", "to", "player_code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_all_agent_rebate_contributors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_all_agent_rebate_records",
                schema: "dbo");
        }
    }
}
