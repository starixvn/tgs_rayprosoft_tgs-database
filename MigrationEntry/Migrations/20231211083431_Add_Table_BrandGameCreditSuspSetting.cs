using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_BrandGameCreditSuspSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<JsonDocument>(
                name: "expansions",
                schema: "dbo",
                table: "brand_game_credit_txns",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "擴充",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "擴充");

            migrationBuilder.CreateTable(
                name: "brand_game_credit_susp_settings",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    low_risk = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 60m, comment: "低度風險"),
                    low_notification = table.Column<JsonDocument>(type: "jsonb", nullable: false, defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()), comment: "低度風險通知"),
                    moderate_risk = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 80m, comment: "中度風險"),
                    moderate_notification = table.Column<JsonDocument>(type: "jsonb", nullable: false, defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 緊急加值通知 Warning: Balance too low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度嚴重不足，所有遊戲暫時不可進入；為避免影響平台正常運營，請立即聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a higher balance usage, and the access to all games will be temporarily suspended. To maintain the stability of your site, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()), comment: "中度風險通知"),
                    high_risk = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 95m, comment: "高度風險"),
                    high_notification = table.Column<JsonDocument>(type: "jsonb", nullable: false, defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 平台已停用，請立即加值 Notice of Suspension\",\"Content\":\"貴司您好，由於您的平台剩餘額度已低於限制，平台及所有遊戲暫時不可進入；請立即聯繫貴司對應商務進行加值，並由專人協助您恢復平台運行，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site has been temporarily suspended due to a balance usage that has exceeded the limit. To recover the full access of platform and all games, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()), comment: "高度風險通知"),
                    credit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "信用額度"),
                    credit_notification = table.Column<JsonDocument>(type: "jsonb", nullable: false, defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()), comment: "信用額度通知"),
                    manual_notification = table.Column<JsonDocument>(type: "jsonb", nullable: false, defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()), comment: "手動通知"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_credit_susp_settings", x => x.brand_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_game_credit_susp_settings",
                schema: "dbo");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "expansions",
                schema: "dbo",
                table: "brand_game_credit_txns",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "擴充",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "擴充");
        }
    }
}
