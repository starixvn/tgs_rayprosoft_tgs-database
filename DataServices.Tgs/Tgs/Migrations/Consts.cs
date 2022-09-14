namespace TGS.Core.DataServices.Tgs.Migrations;

internal static class Consts
{
    internal const string BetSchema = "bet";
    internal const string LogSchema = "log";
    internal const string ReportSchema = "report";
    internal static readonly string _FunctionSqlFormat = $"{Namespace}.Functions.{{0}}.sql";
    internal static readonly string _IndexSqlFormat = $"{Namespace}.Indexes.{{0}}.sql";
    internal static readonly string _PaymentInitialSqlFormat = $"{Namespace}.PaymentInitial.{{0}}.sql";
    internal static readonly string _ProcedureSqlFormat = $"{Namespace}.Procedures.{{0}}.sql";
    internal static readonly string _ViewSqlFormat = $"{Namespace}.Views.{{0}}.sql";
    private const string Namespace = "TGS.Core.DataServices.Tgs.SqlScripts";
}
