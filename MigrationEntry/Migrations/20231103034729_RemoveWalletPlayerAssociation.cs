using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class RemoveWalletPlayerAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_wallets_players_player_code",
                schema: "dbo",
                table: "wallets");

            migrationBuilder.DropIndex(
                name: "ix_wallets_player_code",
                schema: "dbo",
                table: "wallets");

            migrationBuilder.AlterColumn<string>(
                name: "player_code",
                schema: "dbo",
                table: "wallets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "external_currency_code",
                schema: "dbo",
                table: "wallets",
                type: "character varying(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "player_code",
                schema: "dbo",
                table: "wallets",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "external_currency_code",
                schema: "dbo",
                table: "wallets",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_wallets_player_code",
                schema: "dbo",
                table: "wallets",
                column: "player_code");

            migrationBuilder.AddForeignKey(
                name: "fk_wallets_players_player_code",
                schema: "dbo",
                table: "wallets",
                column: "player_code",
                principalSchema: "dbo",
                principalTable: "players",
                principalColumn: "player_code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
