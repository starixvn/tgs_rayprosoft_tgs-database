using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class Alter_PlayerVipLevelExp_Add_AccumTurnoverId_AccumDepositId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "accum_deposit_id",
                schema: "dbo",
                table: "player_vip_level_exps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "累積存款識別碼");

            migrationBuilder.AddColumn<Guid>(
                name: "accum_turnover_id",
                schema: "dbo",
                table: "player_vip_level_exps",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "累積有效投注識別碼");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accum_deposit_id",
                schema: "dbo",
                table: "player_vip_level_exps");

            migrationBuilder.DropColumn(
                name: "accum_turnover_id",
                schema: "dbo",
                table: "player_vip_level_exps");
        }
    }
}
