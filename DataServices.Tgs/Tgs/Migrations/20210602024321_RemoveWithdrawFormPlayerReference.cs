using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RemoveWithdrawFormPlayerReference : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AlterColumn<string>(
            name: "user_id",
            schema: "dbo",
            table: "withdraw_forms",
            type: "character varying(16)",
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "text",
            oldNullable: true);

        _ = migrationBuilder.CreateIndex(
            name: "ix_withdraw_forms_player_code",
            schema: "dbo",
            table: "withdraw_forms",
            column: "user_id");

        _ = migrationBuilder.AddForeignKey(
            name: "fk_withdraw_forms_players_player_code",
            schema: "dbo",
            table: "withdraw_forms",
            column: "user_id",
            principalSchema: "dbo",
            principalTable: "players",
            principalColumn: "player_code",
            onDelete: ReferentialAction.Cascade);
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "fk_withdraw_forms_players_player_code",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropIndex(
            name: "ix_withdraw_forms_player_code",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.AlterColumn<string>(
            name: "user_id",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "character varying(16)");
    }
}
