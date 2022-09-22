using Microsoft.EntityFrameworkCore.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class RefactorWithdrawForm : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropColumn(
            name: "user_name",
            schema: "dbo",
            table: "withdraw_forms");

        _ = migrationBuilder.DropColumn(
            name: "user_type",
            schema: "dbo",
            table: "withdraw_forms");
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<string>(
            name: "user_name",
            schema: "dbo",
            table: "withdraw_forms",
            type: "text",
            nullable: true);

        _ = migrationBuilder.AddColumn<int>(
            name: "user_type",
            schema: "dbo",
            table: "withdraw_forms",
            type: "integer",
            nullable: false,
            defaultValue: 0);

        // 舊資料補回新增欄位的資料
        //var assembly = Assembly.GetExecutingAssembly();

        //migrationBuilder.SqlResource(
        //    assembly,
        //    $"TGS.Core.DataServices.Tgs.Migrations.RefactorWithdrawForm.sql");
    }
}
