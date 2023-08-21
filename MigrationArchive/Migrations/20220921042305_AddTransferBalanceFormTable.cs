using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddTransferBalanceFormTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "transfer_balance_forms",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                drawee = table.Column<string>(type: "text", nullable: false),
                drawee_type = table.Column<string>(type: "text", nullable: false),
                payee = table.Column<string>(type: "text", nullable: false),
                payee_type = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_transfer_balance_forms", x => x.id);
                _ = table.ForeignKey(
                    name: "fk_transfer_balance_forms_brands_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id");
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_transfer_balance_forms_brand_id",
            schema: "dbo",
            table: "transfer_balance_forms",
            column: "brand_id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "transfer_balance_forms",
            schema: "dbo");
    }
}
