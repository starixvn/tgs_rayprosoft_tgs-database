using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Table_GameBetRunning_Required_DefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "valid_bet",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "實際/有效下注",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "實際/有效下注");

            migrationBuilder.AlterColumn<string>(
                name: "player_code",
                schema: "dbo",
                table: "game_bet_runnings",
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
                table: "game_bet_runnings",
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
                name: "external_bet_id",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                comment: "三方投注單別碼",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldComment: "三方投注單別碼");

            migrationBuilder.AlterColumn<string>(
                name: "extended_data",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "jsonb",
                nullable: false,
                defaultValueSql: "'{}'::jsonb",
                comment: "擴充數據",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldNullable: true,
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "擴充數據");

            migrationBuilder.AlterColumn<decimal>(
                name: "currency_ratio",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "貨幣比例",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "貨幣比例");

            migrationBuilder.AlterColumn<string>(
                name: "currency_code",
                schema: "dbo",
                table: "game_bet_runnings",
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

            migrationBuilder.AlterColumn<decimal>(
                name: "bet",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "下注",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "下注");

            migrationBuilder.AlterColumn<string>(
                name: "additional_data",
                schema: "dbo",
                table: "game_bet_runnings",
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
            migrationBuilder.AlterColumn<decimal>(
                name: "valid_bet",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "實際/有效下注",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "實際/有效下注");

            migrationBuilder.AlterColumn<string>(
                name: "player_code",
                schema: "dbo",
                table: "game_bet_runnings",
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
                table: "game_bet_runnings",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                comment: "三方局/回合識別碼",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldComment: "三方局/回合識別碼");

            migrationBuilder.AlterColumn<string>(
                name: "external_bet_id",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                comment: "三方投注單別碼",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldComment: "三方投注單別碼");

            migrationBuilder.AlterColumn<string>(
                name: "extended_data",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "jsonb",
                nullable: true,
                defaultValueSql: "'{}'::jsonb",
                comment: "擴充數據",
                oldClrType: typeof(string),
                oldType: "jsonb",
                oldDefaultValueSql: "'{}'::jsonb",
                oldComment: "擴充數據");

            migrationBuilder.AlterColumn<decimal>(
                name: "currency_ratio",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "貨幣比例",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "貨幣比例");

            migrationBuilder.AlterColumn<string>(
                name: "currency_code",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "character varying(16)",
                maxLength: 16,
                nullable: true,
                comment: "貨幣代碼",
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16,
                oldComment: "貨幣代碼");

            migrationBuilder.AlterColumn<decimal>(
                name: "bet",
                schema: "dbo",
                table: "game_bet_runnings",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "下注",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "下注");

            migrationBuilder.AlterColumn<string>(
                name: "additional_data",
                schema: "dbo",
                table: "game_bet_runnings",
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
