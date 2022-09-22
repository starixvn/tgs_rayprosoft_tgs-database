using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddPaymentHandlingFeeTable : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropTable(
            name: "payment_handling_fees",
            schema: "dbo");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.CreateTable(
            name: "payment_handling_fees",
            schema: "dbo",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                amount = table.Column<decimal>(type: "numeric", nullable: false),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                fee = table.Column<decimal>(type: "numeric", nullable: false),
                form_id = table.Column<Guid>(type: "uuid", nullable: false),
                recorded_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                remark = table.Column<string>(type: "jsonb", nullable: true),
                type = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                _ = table.PrimaryKey("pk_payment_handling_fees_id", x => x.id);
                _ = table.ForeignKey(
                    name: "fk_payment_handling_fees_brands_brand_id",
                    column: x => x.brand_id,
                    principalSchema: "dbo",
                    principalTable: "brands",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        _ = migrationBuilder.CreateIndex(
            name: "ix_payment_handling_fees_brand_id",
            schema: "dbo",
            table: "payment_handling_fees",
            column: "brand_id");

        _ = migrationBuilder.CreateIndex(
            name: "ix_payment_handling_fees_form_id",
            schema: "dbo",
            table: "payment_handling_fees",
            column: "form_id")
            .Annotation("Npgsql:IndexInclude", new[] { "amount", "fee", "recorded_on" });

        _ = migrationBuilder.CreateIndex(
            name: "ix_payment_handling_fees_recorded_on_form_id",
            schema: "dbo",
            table: "payment_handling_fees",
            columns: new[] { "recorded_on", "form_id" })
            .Annotation("Npgsql:IndexInclude", new[] { "amount", "fee" });
    }
}
