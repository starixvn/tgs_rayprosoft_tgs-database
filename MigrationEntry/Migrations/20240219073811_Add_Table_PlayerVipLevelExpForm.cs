using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_PlayerVipLevelExpForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_vip_level_exp_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    vip_level = table.Column<int>(type: "integer", nullable: false, comment: "Vip等級"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "類型(1:流水,2:存款)"),
                    auto_state = table.Column<bool>(type: "boolean", nullable: false, comment: "自動狀態(True:自動;False:手動)"),
                    state = table.Column<int>(type: "integer", nullable: false, comment: "狀態"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "金額"),
                    actual_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "實際金額"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    snapshot_exp = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "Snapshot Exp"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "更新時間"),
                    updated_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "更新使用者識別碼"),
                    updated_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "更新使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_exp_forms", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_vip_level_exp_forms",
                schema: "dbo");
        }
    }
}
