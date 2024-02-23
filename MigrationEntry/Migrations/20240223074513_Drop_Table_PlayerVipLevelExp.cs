using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Drop_Table_PlayerVipLevelExp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_vip_level_exp_deposit_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_exp_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_exp_turnover_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_exps",
                schema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "player_vip_level_exp_deposit_records",
                schema: "dbo",
                columns: table => new
                {
                    system_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "系統時間"),
                    hash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false, comment: "Hash"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "附加資料"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "金額"),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "餘額"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    sign = table.Column<int>(type: "integer", nullable: false, comment: "符號(1:正號 -1:負號)"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "類型")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_exp_deposit_records", x => new { x.system_on, x.hash });
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_exp_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    actual_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "實際金額"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "金額"),
                    auto_state = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "自動狀態(True:自動;False:手動)"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    sign = table.Column<int>(type: "integer", nullable: false, comment: "符號(1:正號 -1:負號)"),
                    snapshot_exp = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "Snapshot Exp"),
                    state = table.Column<int>(type: "integer", nullable: false, comment: "狀態"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "類型(1:流水,2:存款)"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "更新時間"),
                    updated_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "更新使用者識別碼"),
                    updated_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "更新使用者名稱"),
                    vip_level = table.Column<int>(type: "integer", nullable: false, comment: "Vip等級")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_exp_forms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_exp_turnover_records",
                schema: "dbo",
                columns: table => new
                {
                    system_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "系統時間"),
                    hash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false, comment: "Hash"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "附加資料"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "金額"),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "餘額"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    sign = table.Column<int>(type: "integer", nullable: false, comment: "符號(1:正號 -1:負號)"),
                    type = table.Column<int>(type: "integer", nullable: false, comment: "類型")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_exp_turnover_records", x => new { x.system_on, x.hash });
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_exps",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    accum_deposit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "累積存款"),
                    accum_deposit_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "累積存款識別碼"),
                    accum_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "累積有效投注"),
                    accum_turnover_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "累積有效投注識別碼")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_exps", x => x.player_code);
                });
        }
    }
}
