namespace Tgs.Migrations;

internal class MigrationConsts
{
    internal static readonly string _FunctionSqlFormat = $"{Namespace}.Functions.{{0}}.sql";
    internal static readonly string _IndexSqlFormat = $"{Namespace}.Indexes.{{0}}.sql";
    internal static readonly string _ProcedureSqlFormat = $"{Namespace}.Procedures.{{0}}.sql";
    internal static readonly string _ViewSqlFormat = $"{Namespace}.Views.{{0}}.sql";

    private const string Namespace = "Tgs.Migrations.SqlScripts";
}
