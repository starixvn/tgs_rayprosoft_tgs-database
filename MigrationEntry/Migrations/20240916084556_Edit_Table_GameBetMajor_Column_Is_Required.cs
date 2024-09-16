using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Table_GameBetMajor_Column_Is_Required : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "player_code",
                schema: "dbo",
                table: "game_bet_majors",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                comment: "玩家代碼",
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16,
                oldNullable: true,
                oldComment: "玩家代碼");

            migrationBuilder.AlterColumn<string>(
                name: "external_round_id",
                schema: "dbo",
                table: "game_bet_majors",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                comment: "三方局/回合識別碼",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "三方局/回合識別碼");

            migrationBuilder.AlterColumn<string>(
                name: "extended_data",
                schema: "dbo",
                table: "game_bet_majors",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "擴充數據",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true,
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "擴充數據");

            migrationBuilder.AlterColumn<string>(
                name: "currency_code",
                schema: "dbo",
                table: "game_bet_majors",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                comment: "貨幣代碼",
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16,
                oldNullable: true,
                oldComment: "貨幣代碼");

            migrationBuilder.AlterColumn<string>(
                name: "additional_data",
                schema: "dbo",
                table: "game_bet_majors",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "附加數據",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true,
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "附加數據");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "player_code",
                schema: "dbo",
                table: "game_bet_majors",
                type: "character varying(16)",
                maxLength: 16,
                nullable: true,
                comment: "玩家代碼",
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16,
                oldComment: "玩家代碼");

            migrationBuilder.AlterColumn<string>(
                name: "external_round_id",
                schema: "dbo",
                table: "game_bet_majors",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                comment: "三方局/回合識別碼",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldComment: "三方局/回合識別碼");

            migrationBuilder.AlterColumn<string>(
                name: "extended_data",
                schema: "dbo",
                table: "game_bet_majors",
                type: "jsonb",
                nullable: true,
                defaultValueSql: "'{}'::jsonb",
                comment: "擴充數據",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "擴充數據");

            migrationBuilder.AlterColumn<string>(
                name: "currency_code",
                schema: "dbo",
                table: "game_bet_majors",
                type: "character varying(16)",
                maxLength: 16,
                nullable: true,
                comment: "貨幣代碼",
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16,
                oldComment: "貨幣代碼");

            migrationBuilder.AlterColumn<string>(
                name: "additional_data",
                schema: "dbo",
                table: "game_bet_majors",
                type: "jsonb",
                nullable: true,
                defaultValueSql: "'{}'::jsonb",
                comment: "附加數據",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "附加數據");
        }
    }
}
