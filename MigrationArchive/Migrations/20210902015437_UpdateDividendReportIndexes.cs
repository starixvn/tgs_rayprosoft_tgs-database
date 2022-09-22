using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class UpdateDividendReportIndexes : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ix_player_game_rebate_aggregates_multiple_keys",
            schema: "report",
            table: "player_game_rebate_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_player_aggregates_agent_id",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_player_aggregates_multiple_keys",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_agent_dividends_agent_id_brand_id_created_on",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.DropIndex(
            name: "ix_agent_dividends_agent_id_sent_on",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.DropIndex(
            name: "ix_agent_dividends_brand_id_from_to",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_game_rebate_aggregates_brand_id_report_date",
            schema: "report",
            table: "player_game_rebate_aggregates",
            columns: new[] { "brand_id", "report_date" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_game_rebate_aggregates_brand_id_report_date_agent_id",
            schema: "report",
            table: "player_game_rebate_aggregates",
            columns: new[] { "brand_id", "report_date", "agent_id" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_game_rebate_aggregates_brand_id_report_date_player_code",
            schema: "report",
            table: "player_game_rebate_aggregates",
            columns: new[] { "brand_id", "report_date", "player_code" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_aggregates_brand_id_report_date",
            schema: "report",
            table: "player_aggregates",
            columns: new[] { "brand_id", "report_date" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_aggregates_brand_id_report_date_agent_id",
            schema: "report",
            table: "player_aggregates",
            columns: new[] { "brand_id", "report_date", "agent_id" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_aggregates_brand_id_report_date_player_code",
            schema: "report",
            table: "player_aggregates",
            columns: new[] { "brand_id", "report_date", "player_code" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_agent_dividends_brand_id",
            schema: "dbo",
            table: "agent_dividends",
            column: "brand_id");

        _ = migrationBuilder.CreateIndex(
            name: "ix_agent_dividends_brand_id_created_on",
            schema: "dbo",
            table: "agent_dividends",
            columns: new[] { "brand_id", "created_on" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_agent_dividends_brand_id_created_on_agent_id",
            schema: "dbo",
            table: "agent_dividends",
            columns: new[] { "brand_id", "created_on", "agent_id" });
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ix_player_game_rebate_aggregates_brand_id_report_date",
            schema: "report",
            table: "player_game_rebate_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_player_game_rebate_aggregates_brand_id_report_date_agent_id",
            schema: "report",
            table: "player_game_rebate_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_player_game_rebate_aggregates_brand_id_report_date_player_code",
            schema: "report",
            table: "player_game_rebate_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_player_aggregates_brand_id_report_date",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_player_aggregates_brand_id_report_date_agent_id",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_player_aggregates_brand_id_report_date_player_code",
            schema: "report",
            table: "player_aggregates");

        _ = migrationBuilder.DropIndex(
            name: "ix_agent_dividends_brand_id",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.DropIndex(
            name: "ix_agent_dividends_brand_id_created_on",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.DropIndex(
            name: "ix_agent_dividends_brand_id_created_on_agent_id",
            schema: "dbo",
            table: "agent_dividends");

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_game_rebate_aggregates_multiple_keys",
            schema: "report",
            table: "player_game_rebate_aggregates",
            columns: new[] { "report_date", "brand_id", "agent_id", "player_code" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_aggregates_agent_id",
            schema: "report",
            table: "player_aggregates",
            column: "agent_id");

        _ = migrationBuilder.CreateIndex(
            name: "ix_player_aggregates_multiple_keys",
            schema: "report",
            table: "player_aggregates",
            columns: new[] { "report_date", "brand_id", "agent_id", "player_code" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_agent_dividends_agent_id_brand_id_created_on",
            schema: "dbo",
            table: "agent_dividends",
            columns: new[] { "agent_id", "brand_id", "created_on" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_agent_dividends_agent_id_sent_on",
            schema: "dbo",
            table: "agent_dividends",
            columns: new[] { "agent_id", "sent_on" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_agent_dividends_brand_id_from_to",
            schema: "dbo",
            table: "agent_dividends",
            columns: new[] { "brand_id", "from", "to" });
    }
}
