using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class PromotionAddAmountSanpshot : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "amount_used_snapshot_id",
            schema: "dbo",
            table: "promotions");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<Guid>(
            name: "amount_used_snapshot_id",
            schema: "dbo",
            table: "promotions",
            type: "uuid",
            nullable: true);
    }
}
