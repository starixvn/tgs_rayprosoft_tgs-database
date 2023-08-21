using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    public partial class AddBrandPaymentAutoWithdrawTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand_payment_auto_withdraw",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_upper_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_payment_candidates = table.Column<string>(type: "jsonb", nullable: false),
                    enable_auto_withdraw = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    snapshot_event_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_auto_withdraw", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_payment_auto_withdraw_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_auto_withdraw_event_source", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_payment_auto_withdraw",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_auto_withdraw_event_source",
                schema: "dbo");
        }
    }
}
