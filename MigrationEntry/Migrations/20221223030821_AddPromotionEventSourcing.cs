using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddPromotionEventSourcing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "snapshot_event_id",
                schema: "dbo",
                table: "promotions",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "promotion_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_event_source", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "promotion_event_source",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "snapshot_event_id",
                schema: "dbo",
                table: "promotions");
        }
    }
}
