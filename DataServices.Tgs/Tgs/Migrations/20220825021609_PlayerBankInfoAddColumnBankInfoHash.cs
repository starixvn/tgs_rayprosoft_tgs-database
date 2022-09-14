using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class PlayerBankInfoAddColumnBankInfoHash : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "bank_info_hash",
            schema: "dbo",
            table: "player_bank_infos");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<byte[]>(
            name: "bank_info_hash",
            schema: "dbo",
            table: "player_bank_infos",
            type: "bytea",
            nullable: true);
    }
}
