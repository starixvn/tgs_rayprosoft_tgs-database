using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TGS.Core.DataServices.Tgs.Migrations
{
    /// <inheritdoc />
    public partial class FixAgentDividendProductFeePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.AlterColumn<int>(
                name: "agent_dividend_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                column: "agent_dividend_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees");

            migrationBuilder.AlterColumn<int>(
                name: "agent_dividend_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_agent_dividend_product_fees_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                column: "agent_id");
        }
    }
}
