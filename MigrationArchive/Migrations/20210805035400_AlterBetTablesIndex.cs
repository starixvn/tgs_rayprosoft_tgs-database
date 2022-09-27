using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;
using Tgs.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class AlterBetTablesIndex : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "rounds_createdon"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "game_actions_external_transaction_id"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "game_actions_external_group_id"));
    }
}
