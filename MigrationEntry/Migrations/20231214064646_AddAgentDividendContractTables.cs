using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddAgentDividendContractTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "contract_id",
                schema: "dbo",
                table: "agent_dividend_multiple_layers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "agent_dividend_contract_id",
                schema: "dbo",
                table: "agent_dividend_conditions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_conditions",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "agent_dividend_contracts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    grade_interval_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    contract_dividend_type = table.Column<short>(type: "smallint", nullable: false),
                    contract_status = table.Column<short>(type: "smallint", nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bet_days = table.Column<int>(type: "integer", nullable: false),
                    created_by_username = table.Column<string>(type: "text", nullable: false),
                    updated_by_username = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_contracts_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_dividend_contracts_agents_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_dividend_id = table.Column<int>(type: "integer", nullable: false),
                    negative_dividend_ids = table.Column<string[]>(type: "text[]", nullable: false),
                    agent_dividend_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sent_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_records_id", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_contracts_agent_id",
                schema: "dbo",
                table: "agent_dividend_contracts",
                column: "agent_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_agent_dividend_records",
                schema: "dbo",
                table: "agent_dividend_records",
                column: "agent_dividend_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agent_dividend_contracts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_records",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "contract_id",
                schema: "dbo",
                table: "agent_dividend_multiple_layers");

            migrationBuilder.DropColumn(
                name: "agent_dividend_contract_id",
                schema: "dbo",
                table: "agent_dividend_conditions");

            migrationBuilder.DropColumn(
                name: "win_loss_amount",
                schema: "dbo",
                table: "agent_dividend_conditions");
        }
    }
}
