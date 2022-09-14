using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AgentTransactionLockedFlowColumns : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "lock_amount",
            schema: "dbo",
            table: "agent_transactions");

        _ = migrationBuilder.DropColumn(
            name: "locked_balance",
            schema: "dbo",
            table: "agent_transactions");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<decimal>(
            name: "lock_amount",
            schema: "dbo",
            table: "agent_transactions",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);

        _ = migrationBuilder.AddColumn<decimal>(
            name: "locked_balance",
            schema: "dbo",
            table: "agent_transactions",
            type: "numeric(18,6)",
            precision: 18,
            scale: 6,
            nullable: false,
            defaultValue: 0m);
    }
}
