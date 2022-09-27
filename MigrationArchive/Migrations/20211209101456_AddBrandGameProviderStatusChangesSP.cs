using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;
using Tgs.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AddBrandGameProviderStatusChangesSP : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_game_providers_status_changes"));
    }
}
