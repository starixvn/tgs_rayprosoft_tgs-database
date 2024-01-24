using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Add_Table_BrandGameCredit : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "brand_game_credits",
            schema: "dbo",
            columns: table => new
            {
                reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                month = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "月份"),
                initial_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "初始額度"),
                credit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "上分額度"),
                debit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下分額度"),
                profit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "利潤額度"),
                created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_brand_game_credits", x => new { x.month, x.reseller_id, x.licensee_id, x.brand_id });
            });

        migrationBuilder.CreateIndex(
            name: "ix_brand_game_credits_brand_id",
            schema: "dbo",
            table: "brand_game_credits",
            columns: new[] { "month", "brand_id" });

        migrationBuilder.CreateIndex(
            name: "ix_brand_game_credits_licensee_id",
            schema: "dbo",
            table: "brand_game_credits",
            columns: new[] { "month", "licensee_id" });

        migrationBuilder.CreateIndex(
            name: "ix_brand_game_credits_month",
            schema: "dbo",
            table: "brand_game_credits",
            column: "month");

        migrationBuilder.CreateIndex(
            name: "ix_brand_game_credits_reseller_id",
            schema: "dbo",
            table: "brand_game_credits",
            columns: new[] { "month", "reseller_id" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "brand_game_credits",
            schema: "dbo");
    }
}
