using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_PlayerVipLevelLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_vip_level_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    type = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "日誌類型"),
                    before = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "之前"),
                    after = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "之後"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_logs", x => new { x.created_on, x.id });
                });

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_logs_created_on",
                schema: "dbo",
                table: "player_vip_level_logs",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_logs_created_on_player_code",
                schema: "dbo",
                table: "player_vip_level_logs",
                columns: new[] { "created_on", "player_code" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_vip_level_logs",
                schema: "dbo");
        }
    }
}
