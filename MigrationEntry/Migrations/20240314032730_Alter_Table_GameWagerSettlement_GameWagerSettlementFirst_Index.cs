using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_Table_GameWagerSettlement_GameWagerSettlementFirst_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_game_wager_settlements",
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
                name: "ix_game_wager_settlements_c_on_g_w_p_id",
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
                name: "ix_game_wager_settlement_firsts_f_on_g_w_p_id",
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
                name: "ix_game_wager_settlements_e_c_on_e_closed_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_e_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_e_resettle_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "external_resettle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_id",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_e_c_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "external_created_on", "updated_on" });

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
                name: "ix_game_wager_settlement_f_e_c_on_e_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_e_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_payoff_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_e_resettle_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "external_resettle_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_id",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "updated_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlement_f_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "external_created_on", "wager_state" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ix_game_wager_settlements_e_c_on_e_closed_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_e_payoff_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_e_resettle_on",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_id",
                schema: "dbo",
                table: "game_wager_settlements");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlements_e_c_on_updated_on",
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
                name: "ix_game_wager_settlement_f_e_c_on_e_closed_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_e_payoff_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_e_resettle_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_id",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_updated_on",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

            migrationBuilder.DropIndex(
                name: "ix_game_wager_settlement_f_e_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlement_firsts");

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
                name: "ix_game_wager_settlements_c_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "game_wager_primary_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_settlements_c_on_wager_state",
                schema: "dbo",
                table: "game_wager_settlements",
                columns: new[] { "created_on", "wager_state" });

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
                name: "ix_game_wager_settlement_firsts_f_on_g_w_p_id",
                schema: "dbo",
                table: "game_wager_settlement_firsts",
                columns: new[] { "first_on", "game_wager_primary_id" });

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
        }
    }
}
