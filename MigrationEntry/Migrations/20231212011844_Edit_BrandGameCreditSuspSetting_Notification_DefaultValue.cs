using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Edit_BrandGameCreditSuspSetting_Notification_DefaultValue : Migration
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

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "moderate_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 緊急加值通知 Warning: Balance too low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度嚴重不足，所有遊戲暫時不可進入；為避免影響平台正常運營，請立即聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a higher balance usage, and the access to all games will be temporarily suspended. To maintain the stability of your site, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "中度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 緊急加值通知 Warning: Balance too low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度嚴重不足，所有遊戲暫時不可進入；為避免影響平台正常運營，請立即聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a higher balance usage, and the access to all games will be temporarily suspended. To maintain the stability of your site, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "中度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "manual_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "手動通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "手動通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "low_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "低度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "低度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "high_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 平台已停用，請立即加值 Notice of Suspension\",\"Content\":\"貴司您好，\\r\\n由於您的平台剩餘額度已低於限制，平台及所有遊戲暫時不可進入；請立即聯繫貴司對應商務進行加值，並由專人協助您恢復平台運行，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site has been temporarily suspended due to a balance usage that has exceeded the limit. To recover the full access of platform and all games, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "高度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 平台已停用，請立即加值 Notice of Suspension\",\"Content\":\"貴司您好，由於您的平台剩餘額度已低於限制，平台及所有遊戲暫時不可進入；請立即聯繫貴司對應商務進行加值，並由專人協助您恢復平台運行，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site has been temporarily suspended due to a balance usage that has exceeded the limit. To recover the full access of platform and all games, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "高度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "credit_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "信用額度通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "信用額度通知");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "moderate_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 緊急加值通知 Warning: Balance too low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度嚴重不足，所有遊戲暫時不可進入；為避免影響平台正常運營，請立即聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a higher balance usage, and the access to all games will be temporarily suspended. To maintain the stability of your site, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "中度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 緊急加值通知 Warning: Balance too low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度嚴重不足，所有遊戲暫時不可進入；為避免影響平台正常運營，請立即聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a higher balance usage, and the access to all games will be temporarily suspended. To maintain the stability of your site, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "中度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "manual_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "手動通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "手動通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "low_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "低度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "低度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "high_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 平台已停用，請立即加值 Notice of Suspension\",\"Content\":\"貴司您好，由於您的平台剩餘額度已低於限制，平台及所有遊戲暫時不可進入；請立即聯繫貴司對應商務進行加值，並由專人協助您恢復平台運行，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site has been temporarily suspended due to a balance usage that has exceeded the limit. To recover the full access of platform and all games, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "高度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 平台已停用，請立即加值 Notice of Suspension\",\"Content\":\"貴司您好，\\r\\n由於您的平台剩餘額度已低於限制，平台及所有遊戲暫時不可進入；請立即聯繫貴司對應商務進行加值，並由專人協助您恢復平台運行，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site has been temporarily suspended due to a balance usage that has exceeded the limit. To recover the full access of platform and all games, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "高度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "credit_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。<br/>Dear Partner,<br/>We wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                comment: "信用額度通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "信用額度通知");
        }
    }
}
