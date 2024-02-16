using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_PlayerVipLevelExpRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_vip_level_exp_deposit_records",
                schema: "dbo",
                columns: table => new
                {
                    hash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false, comment: "Hash"),
                    system_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "系統時間"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "類型"),
                    sign = table.Column<int>(type: "integer", nullable: false, comment: "符號(1:正號 -1:負號)"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "金額"),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "餘額"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "附加資料"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_exp_deposit_records", x => new { x.system_on, x.hash });
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_exp_turnover_records",
                schema: "dbo",
                columns: table => new
                {
                    hash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false, comment: "Hash"),
                    system_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "系統時間"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "類型"),
                    sign = table.Column<int>(type: "integer", nullable: false, comment: "符號(1:正號 -1:負號)"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "金額"),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "餘額"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "附加資料"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_exp_turnover_records", x => new { x.system_on, x.hash });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_vip_level_exp_deposit_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_exp_turnover_records",
                schema: "dbo");
        }
    }
}
