using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using Tgs.Migrations;
using TGS.Core.DataServices.Base.Extensions;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class FixPromotionFunctions : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();

        _ = migrationBuilder.Sql(@"
                drop procedure if exists dbo.promotion_update_amount_used;
                drop function if exists dbo.promotion_revert_amount_used;
            ");

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "promotion_revert_amount_used"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "promotion_update_amount_used"));
    }
}
