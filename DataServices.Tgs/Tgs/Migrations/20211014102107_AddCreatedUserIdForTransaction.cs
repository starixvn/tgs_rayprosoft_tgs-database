using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddCreatedUserIdForTransaction : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "created_by_user_id",
            schema: "dbo",
            table: "transactions");

        _ = migrationBuilder.DropColumn(
            name: "sent_by_username",
            schema: "dbo",
            table: "promotion_players");

        _ = migrationBuilder.DropColumn(
            name: "sent_by_username",
            schema: "dbo",
            table: "player_rebates");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<Guid>(
            name: "created_by_user_id",
            schema: "dbo",
            table: "transactions",
            type: "uuid",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "sent_by_username",
            schema: "dbo",
            table: "promotion_players",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<string>(
            name: "sent_by_username",
            schema: "dbo",
            table: "player_rebates",
            type: "text",
            nullable: true);
    }
}
