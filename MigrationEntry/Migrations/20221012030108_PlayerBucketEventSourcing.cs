using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class PlayerBucketEventSourcing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "snapshot_id",
                schema: "dbo",
                table: "player_buckets",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "player_bucket_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    external_id = table.Column<string>(type: "text", nullable: true),
                    fill_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_event_source", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_bucket_event_source",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "snapshot_id",
                schema: "dbo",
                table: "player_buckets");
        }
    }
}
