using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddGameWagersTableColumnCurrencyRatio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_id",
                schema: "dbo",
                table: "game_wagers");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "dbo",
                table: "game_wagers");

            migrationBuilder.AddColumn<decimal>(
                name: "currency_ratio",
                schema: "dbo",
                table: "game_wagers",
                type: "numeric(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m,
                comment: "貨幣比例");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currency_ratio",
                schema: "dbo",
                table: "game_wagers");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "dbo",
                table: "game_wagers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "識別碼");

            migrationBuilder.CreateIndex(
                name: "ix_id",
                schema: "dbo",
                table: "game_wagers",
                column: "id");
        }
    }
}
