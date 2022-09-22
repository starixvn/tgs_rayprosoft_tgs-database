using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RemoveTransactionPromotionFK : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropIndex(
            name: "ix_transactions_transaction_id",
            schema: "dbo",
            table: "transaction_promotions");

        _ = migrationBuilder.CreateIndex(
            name: "ix_transactions_transaction_id",
            schema: "dbo",
            table: "transaction_promotions",
            column: "transaction_id",
            unique: true);

        _ = migrationBuilder.AddForeignKey(
            name: "fk_transaction_promotion_transaction_id",
            schema: "dbo",
            table: "transaction_promotions",
            column: "transaction_id",
            principalSchema: "dbo",
            principalTable: "transactions",
            principalColumn: "id",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "fk_transaction_promotion_transaction_id",
            schema: "dbo",
            table: "transaction_promotions");

        _ = migrationBuilder.DropIndex(
            name: "ix_transactions_transaction_id",
            schema: "dbo",
            table: "transaction_promotions");

        _ = migrationBuilder.CreateIndex(
            name: "ix_transactions_transaction_id",
            schema: "dbo",
            table: "transaction_promotions",
            column: "transaction_id");
    }
}
