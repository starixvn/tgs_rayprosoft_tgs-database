using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_VipLevelSnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vip_level_snapshots",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    data = table.Column<string>(type: "jsonb", nullable: false, comment: "資料"),
                    effective_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "生效時間"),
                    snapshot_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "快照時間"),
                    snapshot_user_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "快照使用者識別碼"),
                    snapshot_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "快照使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vip_level_snapshots", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vip_level_snapshots_brand_id",
                schema: "dbo",
                table: "vip_level_snapshots",
                column: "brand_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vip_level_snapshots",
                schema: "dbo");
        }
    }
}
