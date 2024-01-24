using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBrandContractTables : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "fk_agent_dividend_contracts_agents_agent_id",
            schema: "dbo",
            table: "agent_dividend_contracts");

        migrationBuilder.DropIndex(
            name: "ix_player_agent_relations_brand_id",
            schema: "dbo",
            table: "player_agent_relations");

        migrationBuilder.DropIndex(
            name: "ix_agent_dividend_contracts_agent_id",
            schema: "dbo",
            table: "agent_dividend_contracts");

        migrationBuilder.RenameColumn(
            name: "contract_id",
            schema: "dbo",
            table: "agent_dividend_multiple_layers",
            newName: "agent_dividend_snapshot_id");

        migrationBuilder.AlterColumn<string>(
            name: "updated_by_username",
            schema: "dbo",
            table: "agent_dividend_contracts",
            type: "character varying(64)",
            maxLength: 64,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "name",
            schema: "dbo",
            table: "agent_dividend_contracts",
            type: "character varying(64)",
            maxLength: 64,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AlterColumn<string>(
            name: "created_by_username",
            schema: "dbo",
            table: "agent_dividend_contracts",
            type: "character varying(64)",
            maxLength: 64,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        migrationBuilder.AddColumn<string[]>(
            name: "game_types",
            schema: "dbo",
            table: "agent_dividend_contracts",
            type: "text[]",
            nullable: false,
            defaultValue: Array.Empty<string>());

        migrationBuilder.CreateTable(
            name: "agent_dividend_snapshots",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                data = table.Column<string>(type: "jsonb", nullable: false),
                created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_agent_dividend_snapshots_id", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "brand_contracts",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                grade_interval_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                contract_dividend_type = table.Column<short>(type: "smallint", nullable: false),
                contract_status = table.Column<short>(type: "smallint", nullable: false),
                valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                bet_days = table.Column<int>(type: "integer", nullable: false),
                game_types = table.Column<string[]>(type: "text[]", nullable: false),
                created_by_username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                updated_by_username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_brand_contracts_id", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "brand_contract_conditions",
            schema: "dbo",
            columns: table => new
            {
                brand_contract_id = table.Column<Guid>(type: "uuid", nullable: false),
                rank = table.Column<int>(type: "integer", nullable: false),
                active_number = table.Column<int>(type: "integer", nullable: false),
                dividend_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_brand_contract_conditions_rank_brand_contract_id", x => new { x.rank, x.brand_contract_id });
                table.ForeignKey(
                    name: "fk_brand_contract_conditions_brand_contract_brand_contract_id",
                    column: x => x.brand_contract_id,
                    principalSchema: "dbo",
                    principalTable: "brand_contracts",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "ix_player_agent_relations_brand_id",
            schema: "dbo",
            table: "player_agent_relations",
            column: "brand_id");

        migrationBuilder.CreateIndex(
            name: "ix_brand_contract_conditions_brand_contract_id",
            schema: "dbo",
            table: "brand_contract_conditions",
            column: "brand_contract_id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "agent_dividend_snapshots",
            schema: "dbo");

        migrationBuilder.DropTable(
            name: "brand_contract_conditions",
            schema: "dbo");

        migrationBuilder.DropTable(
            name: "brand_contracts",
            schema: "dbo");

        migrationBuilder.DropIndex(
            name: "ix_player_agent_relations_brand_id",
            schema: "dbo",
            table: "player_agent_relations");

        migrationBuilder.DropColumn(
            name: "game_types",
            schema: "dbo",
            table: "agent_dividend_contracts");

        migrationBuilder.RenameColumn(
            name: "agent_dividend_snapshot_id",
            schema: "dbo",
            table: "agent_dividend_multiple_layers",
            newName: "contract_id");

        migrationBuilder.AlterColumn<string>(
            name: "updated_by_username",
            schema: "dbo",
            table: "agent_dividend_contracts",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(64)",
            oldMaxLength: 64);

        migrationBuilder.AlterColumn<string>(
            name: "name",
            schema: "dbo",
            table: "agent_dividend_contracts",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(64)",
            oldMaxLength: 64);

        migrationBuilder.AlterColumn<string>(
            name: "created_by_username",
            schema: "dbo",
            table: "agent_dividend_contracts",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "character varying(64)",
            oldMaxLength: 64);

        migrationBuilder.CreateIndex(
            name: "ix_player_agent_relations_brand_id",
            schema: "dbo",
            table: "player_agent_relations",
            column: "brand_id",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "ix_agent_dividend_contracts_agent_id",
            schema: "dbo",
            table: "agent_dividend_contracts",
            column: "agent_id",
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "fk_agent_dividend_contracts_agents_agent_id",
            schema: "dbo",
            table: "agent_dividend_contracts",
            column: "agent_id",
            principalSchema: "dbo",
            principalTable: "agents",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);
    }
}
