using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Add_Table_GameWagerMarker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "game_wager_markers",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "代碼"),
                    marker = table.Column<Guid>(type: "uuid", nullable: false, comment: "標記"),
                    expansions = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "擴充"),
                    directions = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "說明"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_markers", x => x.code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "game_wager_markers",
                schema: "dbo");
        }
    }
}
