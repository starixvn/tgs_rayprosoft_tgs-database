using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;
using Tgs.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AlterPlayerEmailIndex : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.Sql(@"
                drop index if exists dbo.ux_players_email;
            ");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();

        _ = migrationBuilder.Sql(@"
                drop index if exists dbo.ux_players_email;
            ");

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "players_brand_id_email"));
    }
}
