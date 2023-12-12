using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Edit_BrandGameCredit_Jsonb_DefaultValue_Empty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "expansions",
                schema: "dbo",
                table: "brand_game_credit_txns",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "擴充",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "擴充");

            migrationBuilder.AlterColumn<string>(
                name: "moderate_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "中度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "中度風險通知");

            migrationBuilder.AlterColumn<string>(
                name: "manual_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "手動通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "手動通知");

            migrationBuilder.AlterColumn<string>(
                name: "low_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "低度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "低度風險通知");

            migrationBuilder.AlterColumn<string>(
                name: "high_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "高度風險通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                oldComment: "高度風險通知");

            migrationBuilder.AlterColumn<string>(
                name: "credit_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "信用額度通知",
                oldClrType: typeof(JsonDocument),
                oldType: "jsonb",
                oldDefaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
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
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "擴充");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "moderate_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "中度風險通知",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "中度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "manual_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "手動通知",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "手動通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "low_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "低度風險通知",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "低度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "high_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "高度風險通知",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "高度風險通知");

            migrationBuilder.AlterColumn<JsonDocument>(
                name: "credit_notification",
                schema: "dbo",
                table: "brand_game_credit_susp_settings",
                type: "jsonb",
                nullable: false,
                defaultValue: System.Text.Json.JsonDocument.Parse("{}", new System.Text.Json.JsonDocumentOptions()),
                comment: "信用額度通知",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "信用額度通知");
        }
    }
}
