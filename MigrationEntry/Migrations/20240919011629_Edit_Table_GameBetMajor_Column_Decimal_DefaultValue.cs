using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Table_GameBetMajor_Column_Decimal_DefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "win_loss",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "玩家損益/淨利",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "玩家損益/淨利");

            migrationBuilder.AlterColumn<decimal>(
                name: "valid_bet",
                schema: "dbo",
                table: "game_bet_majors",
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

            migrationBuilder.AlterColumn<decimal>(
                name: "settle",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "結算(包含本金)",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "結算(包含本金)");

            migrationBuilder.AlterColumn<decimal>(
                name: "jackpot",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "彩金",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "彩金");

            migrationBuilder.AlterColumn<decimal>(
                name: "currency_ratio",
                schema: "dbo",
                table: "game_bet_majors",
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

            migrationBuilder.AlterColumn<decimal>(
                name: "contribute",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "貢獻/彩金貢獻",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "貢獻/彩金貢獻");

            migrationBuilder.AlterColumn<decimal>(
                name: "commission",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "傭金",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldComment: "傭金");

            migrationBuilder.AlterColumn<decimal>(
                name: "bet",
                schema: "dbo",
                table: "game_bet_majors",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "win_loss",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "玩家損益/淨利",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "玩家損益/淨利");

            migrationBuilder.AlterColumn<decimal>(
                name: "valid_bet",
                schema: "dbo",
                table: "game_bet_majors",
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

            migrationBuilder.AlterColumn<decimal>(
                name: "settle",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "結算(包含本金)",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "結算(包含本金)");

            migrationBuilder.AlterColumn<decimal>(
                name: "jackpot",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "彩金",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "彩金");

            migrationBuilder.AlterColumn<decimal>(
                name: "currency_ratio",
                schema: "dbo",
                table: "game_bet_majors",
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

            migrationBuilder.AlterColumn<decimal>(
                name: "contribute",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "貢獻/彩金貢獻",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "貢獻/彩金貢獻");

            migrationBuilder.AlterColumn<decimal>(
                name: "commission",
                schema: "dbo",
                table: "game_bet_majors",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                comment: "傭金",
                oldClrType: typeof(decimal),
                oldType: "numeric(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldDefaultValue: 0m,
                oldComment: "傭金");

            migrationBuilder.AlterColumn<decimal>(
                name: "bet",
                schema: "dbo",
                table: "game_bet_majors",
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
        }
    }
}
