using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;
using TGS.Core.DataServices.Base.Extensions;
using Tgs.Migrations;

namespace TGS.Core.DataServices.Tgs.Migrations;

public partial class Initial
{
    private static void InitAfterRun(MigrationBuilder migrationBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();

        #region Procedures

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._ProcedureSqlFormat, "player_deauthorize_by_login_record_id"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._ProcedureSqlFormat, "player_deauthorize_by_platform_type"));

        #endregion Procedures

        #region Functions

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_brand_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_brand_game_provider_configuration_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_brand_game_providers_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_brand_games_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_languages_by_external_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_languages_by_internal_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_currencies_by_external_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "brand_get_currencies_by_internal_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_currencies_by_external_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_currencies_by_internal_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_languages_by_external_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_languages_by_internal_code"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_game_provider_configuration_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_games_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_game_provider_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_provider_get_sub_games"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "localization_get_localization_by_game_provider_id"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "player_get_player_for_cache"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "player_get_player_login_records"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "wallet_get_balance"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "wallet_update_wallet_balance"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_action_get_game_actions_in_same_round"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_action_get_game_action_external_ids"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_action_get_valid_game_action_external_ids"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_action_get_game_actions_by_external_round_id"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_action_get_game_actions_by_external_transaction_id"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "game_action_referenced_game_action_exists"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "report_get_round_aggregates"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "agent_wallet_update_wallet_balance"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "report_get_player_account_change_records"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "log_get_admin_log"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "log_get_admin_logs"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "log_get_api_log"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "log_get_api_logs"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "log_get_log_records"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "admin_logs"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "api_logs"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "log_records"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "agents_email"));

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._FunctionSqlFormat, "report_get_round_aggregates"));

        #endregion Functions

        #region Views

        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._ViewSqlFormat, "vw_valid_game_actions"));

        #endregion Views

        #region Specific Indexes

        // unique index of players for lower case username, instead of alternative key
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "players"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "resellers"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "licensees"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "brands"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "payments"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "roles"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "users"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "games"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "gameProviders"));
        migrationBuilder.SqlResource(assembly,
            string.Format(MigrationConsts._IndexSqlFormat, "players_email"));

        #endregion Specific Indexes
    }
}
