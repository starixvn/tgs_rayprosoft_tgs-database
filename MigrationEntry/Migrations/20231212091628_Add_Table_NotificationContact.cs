using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_NotificationContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notification_contacts",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "總公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "平台識別碼"),
                    type = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "通知類型(信箱、Skype、Telegram)"),
                    contacts = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "聯絡方式"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notification_contacts", x => new { x.reseller_id, x.licensee_id, x.brand_id, x.type });
                });

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_brand_id",
                schema: "dbo",
                table: "notification_contacts",
                columns: new[] { "brand_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_licensee_id",
                schema: "dbo",
                table: "notification_contacts",
                columns: new[] { "licensee_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_reseller_id",
                schema: "dbo",
                table: "notification_contacts",
                columns: new[] { "reseller_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_typ",
                schema: "dbo",
                table: "notification_contacts",
                column: "type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification_contacts",
                schema: "dbo");
        }
    }
}
