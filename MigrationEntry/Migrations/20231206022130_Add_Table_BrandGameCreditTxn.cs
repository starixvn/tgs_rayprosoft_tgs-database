using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_BrandGameCreditTxn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand_game_credit_txns",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    type = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "交易類型"),
                    money = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "金錢"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "額度"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    expansions = table.Column<JsonDocument>(type: "jsonb", nullable: false, defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()), comment: "擴充"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_credit_txns", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credit_txns_brand_id",
                schema: "dbo",
                table: "brand_game_credit_txns",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credit_txns_created_on_brand_id",
                schema: "dbo",
                table: "brand_game_credit_txns",
                columns: new[] { "created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credit_txns_created_on_brand_id_type",
                schema: "dbo",
                table: "brand_game_credit_txns",
                columns: new[] { "created_on", "brand_id", "type" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_game_credit_txns",
                schema: "dbo");
        }
    }
}
