using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class PlayerBucketCleanFormTableExtendColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "clear_wagering_requirement_balance",
                schema: "dbo",
                table: "player_bucket_clean_forms",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "game_balance_return",
                schema: "dbo",
                table: "player_bucket_clean_forms",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "wallet_id",
                schema: "dbo",
                table: "player_bucket_clean_forms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clear_wagering_requirement_balance",
                schema: "dbo",
                table: "player_bucket_clean_forms");

            migrationBuilder.DropColumn(
                name: "game_balance_return",
                schema: "dbo",
                table: "player_bucket_clean_forms");

            migrationBuilder.DropColumn(
                name: "wallet_id",
                schema: "dbo",
                table: "player_bucket_clean_forms");
        }
    }
}
