using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tgs.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "log");

            migrationBuilder.EnsureSchema(
                name: "report");

            migrationBuilder.EnsureSchema(
                name: "bet");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:ltree", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_trgm", ",,");

            migrationBuilder.CreateTable(
                name: "account_event_sources",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_account_event_sources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    algorithm = table.Column<string>(type: "text", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.UniqueConstraint("ux_accounts_username_system_brand", x => new { x.user_name, x.system, x.brand_id });
                });

            migrationBuilder.CreateTable(
                name: "adjust_agent_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    adjustment_type = table.Column<short>(type: "smallint", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    remark = table.Column<string>(type: "text", nullable: true),
                    transaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    transfer_target = table.Column<string>(type: "text", nullable: true),
                    transfer_type = table.Column<short>(type: "smallint", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adjust_agent_records_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adjust_player_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    adjustment_type = table.Column<short>(type: "smallint", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    include_in_net_profit = table.Column<bool>(type: "boolean", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    remark = table.Column<string>(type: "text", nullable: true),
                    transaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    transaction_recorded_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    transfer_target = table.Column<string>(type: "text", nullable: true),
                    transfer_type = table.Column<short>(type: "smallint", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adjust_player_record_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "adjust_transfer_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    transaction_from_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transaction_to_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transfer_from_username = table.Column<string>(type: "text", nullable: false),
                    transfer_to_username = table.Column<string>(type: "text", nullable: false),
                    transfer_type = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_adjust_transfer_record_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "admin_logs",
                schema: "log",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    exception = table.Column<string>(type: "text", nullable: true),
                    execution_time_ms = table.Column<int>(type: "integer", nullable: false),
                    inner_exception = table.Column<string>(type: "text", nullable: true),
                    ip = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    method = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    path = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    recorded_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    request_content = table.Column<string>(type: "text", nullable: false),
                    request_headers = table.Column<string>(type: "text", nullable: false),
                    response_code = table.Column<short>(type: "smallint", nullable: false),
                    response_content = table.Column<string>(type: "text", nullable: false),
                    response_headers = table.Column<string>(type: "text", nullable: false),
                    server_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    stack_trace = table.Column<string>(type: "text", nullable: true),
                    tracking_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admin_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_clear_commission_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_dividend_id = table.Column<int>(type: "integer", nullable: false),
                    commission_amount = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    clear_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_clear_commission_records_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_daily_marketing_statistics",
                schema: "dbo",
                columns: table => new
                {
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    gaming_count = table.Column<int>(type: "integer", nullable: false),
                    register_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_daily_marketing_statistics", x => new { x.report_date, x.brand_id, x.agent_id });
                });

            migrationBuilder.CreateTable(
                name: "agent_daily_payment_statistics",
                schema: "dbo",
                columns: table => new
                {
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    daily_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    deposit_players = table.Column<int>(type: "integer", nullable: false),
                    first_deposit_players = table.Column<int>(type: "integer", nullable: false),
                    undeposit_again_players = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_daily_payment_statistics", x => new { x.report_date, x.brand_id, x.agent_id });
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_contracts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    default_brand_contract_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    grade_interval_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    contract_dividend_type = table.Column<short>(type: "smallint", nullable: false),
                    contract_status = table.Column<short>(type: "smallint", nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bet_days = table.Column<int>(type: "integer", nullable: false),
                    game_types = table.Column<string[]>(type: "text[]", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_contracts_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_product_fees",
                schema: "dbo",
                columns: table => new
                {
                    agent_dividend_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    to = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    card_game_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_product_fees_id", x => x.agent_dividend_id);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    negative_agent_dividend_carry_forward = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    agent_dividend_id = table.Column<int>(type: "integer", nullable: false),
                    negative_agent_dividend_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    agent_dividend_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    actual_agent_dividend_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    remark = table.Column<string>(type: "text", nullable: true),
                    sent_by_username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    approved_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_records_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_snapshots",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_snapshots_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividends",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agent_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    agent_dividend_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    agent_dividend_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    arcade_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    before_dividend_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bonus_adjust_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    bonus_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_game_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    company_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposit_handling_fee = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    e_sports_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    fishing_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    live_dealer_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    no_include_net_profit_agent_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    no_include_net_profit_bonus_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    no_include_net_profit_company_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    original_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    promotion_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    referenced_agent_dividend_id = table.Column<int>(type: "integer", nullable: true),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    slot_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    table_game_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    withdrawal_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    withdraw_handling_fee = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    negative_agent_dividend_carry_forward = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividends_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: true),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_product_fees",
                schema: "dbo",
                columns: table => new
                {
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    previous_card_game_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    previous_live_dealer_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    previous_lottery_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    previous_slot_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    previous_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    previous_virtual_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    current_card_game_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    current_live_dealer_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    current_lottery_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    current_slot_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    current_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    current_virtual_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    next_card_game_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    next_live_dealer_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    next_lottery_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    next_slot_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    next_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    next_virtual_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_by_username = table.Column<string>(type: "text", nullable: false),
                    updated_by_username = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_product_fees", x => x.agent_id);
                });

            migrationBuilder.CreateTable(
                name: "aggregate_execution_time",
                schema: "report",
                columns: table => new
                {
                    aggregate_type = table.Column<short>(type: "smallint", nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aggregate_execution_time_id", x => new { x.aggregate_type, x.from, x.to });
                });

            migrationBuilder.CreateTable(
                name: "api_logs",
                schema: "log",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    execution_time_ms = table.Column<int>(type: "integer", nullable: false),
                    ip = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    method = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    prefix = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    recorded_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    request_content = table.Column<string>(type: "text", nullable: false),
                    request_headers = table.Column<string>(type: "text", nullable: false),
                    response_code = table.Column<short>(type: "smallint", nullable: false),
                    response_content = table.Column<string>(type: "text", nullable: false),
                    response_headers = table.Column<string>(type: "text", nullable: false),
                    server_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    tracking_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_api_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "background_payment_statistics_settings",
                schema: "dbo",
                columns: table => new
                {
                    record_key = table.Column<string>(type: "text", nullable: false),
                    processed_time = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_background_payment_statistics_settings", x => x.record_key);
                });

            migrationBuilder.CreateTable(
                name: "brand_all_agent_game_type_conditions",
                schema: "dbo",
                columns: table => new
                {
                    all_agent_game_type = table.Column<int>(type: "integer", nullable: false),
                    all_agent_rebate_type = table.Column<short>(type: "smallint", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_all_agent_game_type_conditions", x => new { x.brand_id, x.all_agent_game_type, x.rank, x.all_agent_rebate_type });
                });

            migrationBuilder.CreateTable(
                name: "brand_all_agent_game_types",
                schema: "dbo",
                columns: table => new
                {
                    all_agent_game_type = table.Column<short>(type: "smallint", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_valid_bet = table.Column<bool>(type: "boolean", nullable: false),
                    has_win_loss = table.Column<bool>(type: "boolean", nullable: false),
                    @switch = table.Column<bool>(name: "switch", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_all_agent_game_types", x => new { x.brand_id, x.all_agent_game_type });
                });

            migrationBuilder.CreateTable(
                name: "brand_all_agent_settings",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    @switch = table.Column<bool>(name: "switch", type: "boolean", nullable: false),
                    settlement_interval_type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_all_agent_settings", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_all_agents",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_all_agents", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_contracts",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    grade_interval_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    contract_dividend_type = table.Column<short>(type: "smallint", nullable: false),
                    contract_status = table.Column<short>(type: "smallint", nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bet_days = table.Column<int>(type: "integer", nullable: false),
                    game_types = table.Column<string[]>(type: "text[]", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_contracts_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brand_daily_marketing_statistics",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    directly_player_gaming_count = table.Column<int>(type: "integer", nullable: true, comment: "無直屬代理的玩家遊戲人數"),
                    directly_player_register_count = table.Column<int>(type: "integer", nullable: true, comment: "無直屬代理的玩家註冊人數"),
                    total_player_gaming_count = table.Column<int>(type: "integer", nullable: true, comment: "玩家總遊戲人數"),
                    total_player_register_count = table.Column<int>(type: "integer", nullable: true, comment: "玩家總註冊人數")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_daily_marketing_statistics", x => new { x.report_date, x.brand_id });
                });

            migrationBuilder.CreateTable(
                name: "brand_daily_payment_statistics",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    daily_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_deposit_approved_count = table.Column<int>(type: "integer", nullable: true),
                    daily_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_deposit_reject_count = table.Column<int>(type: "integer", nullable: true),
                    daily_deposit_total_count = table.Column<int>(type: "integer", nullable: true),
                    daily_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    deposit_players = table.Column<int>(type: "integer", nullable: false),
                    first_deposit_players = table.Column<int>(type: "integer", nullable: false),
                    undeposit_again_players = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_daily_payment_statistics", x => new { x.report_date, x.brand_id });
                });

            migrationBuilder.CreateTable(
                name: "brand_game_credit_profits",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    month = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "月份"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    profit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "利潤額度")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_credit_profits", x => new { x.brand_id, x.month, x.game_provider_id });
                });

            migrationBuilder.CreateTable(
                name: "brand_game_credit_susp_settings",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    low_risk = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 60m, comment: "低度風險"),
                    low_notification = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "低度風險通知"),
                    moderate_risk = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 80m, comment: "中度風險"),
                    moderate_notification = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "中度風險通知"),
                    high_risk = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 95m, comment: "高度風險"),
                    high_notification = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "高度風險通知"),
                    credit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "信用額度"),
                    credit_notification = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "信用額度通知"),
                    manual_notification = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "手動通知"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_credit_susp_settings", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_game_credit_txns",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    type = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "交易類型"),
                    money = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "金錢"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "額度"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    expansions = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "擴充"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_credit_txns", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brand_game_credits",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    month = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "月份"),
                    initial_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "初始額度"),
                    credit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "上分額度"),
                    debit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下分額度"),
                    profit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "利潤額度"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_credits", x => new { x.month, x.reseller_id, x.licensee_id, x.brand_id });
                });

            migrationBuilder.CreateTable(
                name: "brand_game_provider_aggregate_audit_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_provider_aggregate_audit_log_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brand_game_provider_aggregate_records",
                schema: "report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    audit_log_id = table.Column<int>(type: "integer", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_provider_aggregate_record_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brand_game_provider_aggregates",
                schema: "report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    audit_log_id = table.Column<int>(type: "integer", nullable: false),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    currency_code = table.Column<string>(type: "text", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    settle_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    transaction_count = table.Column<int>(type: "integer", nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_provider_aggregate_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brand_payment_audit_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    after = table.Column<string>(type: "jsonb", nullable: false),
                    before = table.Column<string>(type: "jsonb", nullable: false),
                    brand_payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    operation = table.Column<short>(type: "smallint", nullable: false),
                    reason = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_audit_logs", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "brand_player_bankinfo_check_flags",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_enabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_player_bankinfo_check_flags", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_player_contract_display",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    is_visualized = table.Column<bool>(type: "boolean", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    created_by = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    updated_by = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_player_contract_display", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brand_product_fees",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_game_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_by_username = table.Column<string>(type: "text", nullable: false),
                    updated_by_username = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_product_fees", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "brand_sms",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sms_setting_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_sms", x => new { x.brand_id, x.sms_setting_id });
                });

            migrationBuilder.CreateTable(
                name: "calculate",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_calculate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "calculate_change_log",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    calculate_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change = table.Column<decimal>(type: "numeric", nullable: false),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    recorded_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_calculate_change_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    native_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    symbol = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "deposit_form_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: true),
                    form_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deposit_form_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "deposit_promotion_calculate_pairs",
                schema: "dbo",
                columns: table => new
                {
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    calculate_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deposit_promotion_calculate_pairs", x => x.promotion_id);
                });

            migrationBuilder.CreateTable(
                name: "deposit_promotion_statistics",
                schema: "dbo",
                columns: table => new
                {
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    processed_date = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    total_deposit_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deposit_promotion_statistics", x => new { x.promotion_id, x.player_code });
                });

            migrationBuilder.CreateTable(
                name: "failed_game_record_operations",
                schema: "bet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    auto_status = table.Column<short>(type: "smallint", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    detail = table.Column<string>(type: "text", nullable: false),
                    external_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    game_provider_code = table.Column<string>(type: "text", nullable: true),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    proces_status = table.Column<short>(type: "smallint", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_failed_game_record_operations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "five_minutes_payment_statistics",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    time_point = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    deposit_count = table.Column<int>(type: "integer", nullable: true),
                    withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    withdraw_count = table.Column<int>(type: "integer", nullable: true),
                    first_deposit_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    first_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_on = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_five_minutes_payment_statistics", x => new { x.time_point, x.user_id, x.user_type });
                });

            migrationBuilder.CreateTable(
                name: "five_minutes_payment_statistics_delta",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    time_point = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    deposit_count = table.Column<int>(type: "integer", nullable: false),
                    withdraw_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    withdraw_count = table.Column<int>(type: "integer", nullable: false),
                    deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: false),
                    withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_five_minutes_payment_statistics_delta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_bets",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_bet_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注單別碼"),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方下注/創建時間"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方結算/結束時間"),
                    external_payoff_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方派彩時間"),
                    external_resettle_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "三方重新結算時間"),
                    bet_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單狀態"),
                    bet_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單類型"),
                    free_game_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "免費遊戲狀態"),
                    gamble_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "博取遊戲狀態"),
                    cashout_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "兌現狀態"),
                    resettle_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重新結算狀態"),
                    jackpot_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "彩金狀態"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    jackpot = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "彩金"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "結束時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                    reset_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重置狀態"),
                    reset_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "'1970-01-01 00:00:00+00'::timestamp with time zone", comment: "重置時間"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "附加數據")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_bets", x => new { x.external_created_on, x.game_provider_id, x.game_id, x.wallet_id, x.external_bet_id });
                });

            migrationBuilder.CreateTable(
                name: "game_betting",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "錢包識別碼"),
                    external_bet_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方投注單別碼"),
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商設定識別碼"),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "text", nullable: false, comment: "玩家代碼"),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "貨幣代碼"),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "三方局/回合識別碼"),
                    bet_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "注單類型"),
                    currency_ratio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "貨幣比例"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間"),
                    additional_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}", comment: "附加數據")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_betting", x => new { x.game_provider_id, x.game_id, x.wallet_id, x.external_bet_id });
                });

            migrationBuilder.CreateTable(
                name: "game_provider_aggregate_audit_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_aggregate_audit_log_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_provider_aggregate_records",
                schema: "report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    audit_log_id = table.Column<int>(type: "integer", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_aggregate_record_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_provider_aggregates",
                schema: "report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    audit_log_id = table.Column<int>(type: "integer", nullable: false),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    currency_code = table.Column<string>(type: "text", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    settle_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    transaction_count = table.Column<int>(type: "integer", nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_aggregate_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_provider_fund_transfer_transactions",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_fund_transfer_transaction_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    from_wallet = table.Column<string>(type: "text", nullable: false),
                    fund_source = table.Column<short>(type: "smallint", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_provider_transaction_id = table.Column<string>(type: "text", nullable: true),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    to_wallet = table.Column<string>(type: "text", nullable: false),
                    transaction_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_fund_transfer_transaction_id", x => x.game_provider_fund_transfer_transaction_id);
                });

            migrationBuilder.CreateTable(
                name: "game_providers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    allow_kick_player = table.Column<bool>(type: "boolean", nullable: false),
                    auto_close_round = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    localization = table.Column<string>(type: "jsonb", nullable: true),
                    place_bet_timeout = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    settle_bet_timeout = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    support_test_player = table.Column<bool>(type: "boolean", nullable: false),
                    transfer_wallet = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    unique_id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "game_type_round_aggregates",
                schema: "report",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    to = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    vip_level = table.Column<int>(type: "integer", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: false),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    original_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    round_count = table.Column<int>(type: "integer", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_type_round_aggregate_id", x => new { x.brand_id, x.game_id, x.player_code, x.from, x.to });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_player_accums",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    accum_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "累積時間"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_player_accums", x => new { x.accum_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_stat_closes",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_stat_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code, x.game_provider_id, x.game_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_stat_daily_closes",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                    stat_day_on = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "統計日時間"),
                    stat_time_span = table.Column<TimeSpan>(type: "interval", nullable: false, defaultValueSql: "'+00:00:00':: interval", comment: "統計時間跨度"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_stat_daily_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code, x.game_provider_id, x.game_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_stat_daily_zone_closes",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                    stat_day_on = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "統計日時間"),
                    stat_time_span = table.Column<TimeSpan>(type: "interval", nullable: false, defaultValueSql: "'+00:00:00':: interval", comment: "統計時間跨度"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_stat_daily_zone_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code, x.game_provider_id, x.game_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_stat_hourly_closes",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                    stat_day_on = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "統計日時間"),
                    stat_hour_on = table.Column<TimeOnly>(type: "time without time zone", nullable: false, defaultValueSql: "'00:00:00':: time", comment: "統計小時時間"),
                    stat_time_span = table.Column<TimeSpan>(type: "interval", nullable: false, defaultValueSql: "'+00:00:00':: interval", comment: "統計時間跨度"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_stat_hourly_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code, x.game_provider_id, x.game_id });
                });

            migrationBuilder.CreateTable(
                name: "game_wager_stat_hourly_zone_closes",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "分公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "遊戲供應商識別碼"),
                    game_id = table.Column<int>(type: "integer", nullable: false, comment: "遊戲識別碼"),
                    stat_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "統計時間"),
                    stat_day_on = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "'1990-01-01':: date", comment: "統計日時間"),
                    stat_hour_on = table.Column<TimeOnly>(type: "time without time zone", nullable: false, defaultValueSql: "'00:00:00':: time", comment: "統計小時時間"),
                    stat_time_span = table.Column<TimeSpan>(type: "interval", nullable: false, defaultValueSql: "'+00:00:00':: interval", comment: "統計時間跨度"),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "筆數"),
                    bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "下注"),
                    valid_bet = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "實際/有效下注"),
                    settle = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "結算(包含本金)"),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "傭金"),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "有效投注"),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m, comment: "玩家損益/淨利"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_wager_stat_hourly_zone_closes", x => new { x.stat_on, x.reseller_id, x.licensee_id, x.brand_id, x.player_code, x.game_provider_id, x.game_id });
                });

            migrationBuilder.CreateTable(
                name: "hour_payment_statistics",
                schema: "dbo",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false),
                    time_point = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    deposit_count = table.Column<int>(type: "integer", nullable: true),
                    withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    withdraw_count = table.Column<int>(type: "integer", nullable: true),
                    first_deposit_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    first_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_on = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hour_payment_statistics", x => new { x.time_point, x.user_id, x.user_type });
                });

            migrationBuilder.CreateTable(
                name: "languages",
                schema: "dbo",
                columns: table => new
                {
                    culture_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    language_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    localized_name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.culture_code);
                });

            migrationBuilder.CreateTable(
                name: "log_records",
                schema: "log",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    exception = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    logger = table.Column<string>(type: "text", nullable: true),
                    message = table.Column<string>(type: "text", nullable: false),
                    recorded_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    server_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    tracking_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_log_records", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "marketing_report_daily_aggregates",
                schema: "report",
                columns: table => new
                {
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    first_deposit_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    gaming_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    register_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_marketing_report_daily_aggregates_report_date_agent_id", x => new { x.report_date, x.agent_id });
                });

            migrationBuilder.CreateTable(
                name: "marketing_statistics_settings",
                schema: "dbo",
                columns: table => new
                {
                    record_key = table.Column<string>(type: "text", nullable: false),
                    processed_time = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_marketing_statistics_settings", x => x.record_key);
                });

            migrationBuilder.CreateTable(
                name: "notification_contacts",
                schema: "dbo",
                columns: table => new
                {
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "總公司識別碼"),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "公司識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "平台識別碼"),
                    type = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "通知類型(信箱、Skype、Telegram)"),
                    contacts = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "聯絡方式"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "修改時間")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notification_contacts", x => new { x.reseller_id, x.licensee_id, x.brand_id, x.type });
                });

            migrationBuilder.CreateTable(
                name: "offline_deposit_events",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    deposit_form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    settings = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offline_deposit_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_channels",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_channels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_methods",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank_type = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_methods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    extend_data = table.Column<string>(type: "jsonb", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "0"),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()"),
                    name = table.Column<string>(type: "text", nullable: true),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_aggregates",
                schema: "report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agent_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    all_agent_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bonus_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bonus_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    company_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposit_handling_fee = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    dividend_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    first_fund_in_count = table.Column<int>(type: "integer", nullable: false),
                    hour = table.Column<int>(type: "integer", nullable: false),
                    minute = table.Column<int>(type: "integer", nullable: false),
                    no_include_net_profit_agent_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    no_include_net_profit_bonus_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    no_include_net_profit_company_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    original_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    promotion_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    registered_count = table.Column<int>(type: "integer", nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    report_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    system_adjust_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    withdrawal_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    withdraw_handling_fee = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    agent_dividend_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    chief_agent_dividend_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    agent_dividend_percentage_tree_data = table.Column<string>(type: "jsonb", nullable: true),
                    round_count = table.Column<int>(type: "integer", nullable: false),
                    season_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    upgrade_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    birthday_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_aggregates_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_all_agent_rebate_contributors",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    child_player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    sports_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_turnover_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_win_loss_rebate = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    settle_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_all_agent_rebates_contributor_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_all_agent_rebate_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    all_agent_game_type = table.Column<short>(type: "smallint", nullable: false),
                    all_agent_rebate_type = table.Column<short>(type: "smallint", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    condition_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    actual_player_number = table.Column<int>(type: "integer", nullable: false),
                    actual_condition_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    settle_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_all_agent_rebate_records_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_all_agent_rebates",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    actual_condition_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    actual_player_number = table.Column<int>(type: "integer", nullable: false),
                    all_agent_game_type = table.Column<short>(type: "smallint", nullable: false),
                    all_agent_rebate_type = table.Column<short>(type: "smallint", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    condition_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_all_agent_rebates_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_audit_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    module_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    operation = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_audit_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_authentication_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    data = table.Column<string>(type: "jsonb", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    remark = table.Column<string>(type: "text", nullable: true),
                    reviewed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    reviewed_user_id = table.Column<string>(type: "text", nullable: true),
                    reviewed_user_name = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_authentication_forms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_bank_info_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank_info_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_action = table.Column<string>(type: "text", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    modifier = table.Column<string>(type: "text", nullable: true),
                    modified_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bank_info_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_bonus_aggregates",
                schema: "report",
                columns: table => new
                {
                    hour = table.Column<int>(type: "integer", nullable: false),
                    minute = table.Column<int>(type: "integer", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    birthday_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    promotion_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    report_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    season_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    upgrade_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bonus_aggregates_id", x => new { x.player_code, x.hour, x.minute, x.report_date });
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_clean_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    form_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_clean_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_clean_event_source2",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    form_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_clean_event_source2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    external_id = table.Column<string>(type: "text", nullable: true),
                    fill_type = table.Column<string>(type: "text", nullable: false),
                    remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_histories",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    player_bucket_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    round_data = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}"),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_histories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_migrations",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_migrations", x => x.player_code);
                });

            migrationBuilder.CreateTable(
                name: "player_buckets",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bucket_type = table.Column<short>(type: "smallint", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    current_bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    is_full = table.Column<bool>(type: "boolean", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_buckets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_daily_gaming_statistics",
                schema: "dbo",
                columns: table => new
                {
                    gp_code = table.Column<string>(type: "text", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    sub_gp_code = table.Column<string>(type: "text", nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_daily_gaming_statistics", x => new { x.report_date, x.player_code, x.gp_code, x.sub_gp_code });
                });

            migrationBuilder.CreateTable(
                name: "player_daily_payment_statistics",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "text", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    daily_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_deposit_count = table.Column<int>(type: "integer", nullable: true),
                    daily_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    daily_withdraw_count = table.Column<int>(type: "integer", nullable: true),
                    daily_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    first_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    total_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    total_deposit_count = table.Column<int>(type: "integer", nullable: true),
                    total_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    total_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    total_withdraw_count = table.Column<int>(type: "integer", nullable: true),
                    total_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_daily_payment_statistics", x => new { x.report_date, x.player_code });
                });

            migrationBuilder.CreateTable(
                name: "player_daily_register_statistics",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "text", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    daily_login_count = table.Column<int>(type: "integer", nullable: false),
                    last_login_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    total_login_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_daily_register_statistics", x => new { x.report_date, x.player_code });
                });

            migrationBuilder.CreateTable(
                name: "player_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: true),
                    player_code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_game_rebate_aggregates",
                schema: "report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: false),
                    hour = table.Column<int>(type: "integer", nullable: false),
                    minute = table.Column<int>(type: "integer", nullable: false),
                    original_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    report_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_card_game_rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    vip_level = table.Column<int>(type: "integer", nullable: true),
                    vip_live_dealer_rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    vip_lottery_rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    vip_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_slot_rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    vip_sports_rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    vip_virtual_sports_rebate_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    round_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_game_rebate_aggregates_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_parents",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    parent_player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_parent_code", x => x.player_code);
                });

            migrationBuilder.CreateTable(
                name: "player_payment_overview",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "text", nullable: false),
                    first_deposit_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_deposit_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    first_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_handling_fee = table.Column<decimal>(type: "numeric", nullable: true),
                    first_withdraw_on = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    recorded_by = table.Column<DateOnly>(type: "date", nullable: false),
                    total_deposit_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_withdraw_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    total_deposit_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    total_withdraw_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_payment_overview", x => x.player_code);
                });

            migrationBuilder.CreateTable(
                name: "player_rebates",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_game_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    card_game_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    live_dealer_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sent_by_username = table.Column<string>(type: "text", nullable: true),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    slot_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_card_game_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_live_dealer_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_lottery_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_slot_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_sports_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    vip_virtual_sports_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_rebate_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    virtual_sports_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_rebates_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_tags",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    tag = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tag_player_code_tag", x => new { x.tag, x.player_code });
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_birthday_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    vip_level = table.Column<int>(type: "integer", nullable: false, comment: "Vip等級"),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false, comment: "生日"),
                    auto_state = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "自動狀態(True:自動;False:手動)"),
                    state = table.Column<int>(type: "integer", nullable: false, comment: "狀態"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "金額"),
                    actual_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "實際金額"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    snapshot_vip_level = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "Snapshot Vip Level"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "更新時間"),
                    updated_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "更新使用者識別碼"),
                    updated_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "更新使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_birthday_forms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_cycle_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    vip_level = table.Column<int>(type: "integer", nullable: false, comment: "Vip等級"),
                    cycle_type = table.Column<int>(type: "integer", nullable: false, comment: "週期類型(1:日 2:周 3:月)"),
                    cycle_on = table.Column<DateOnly>(type: "date", nullable: false, comment: "週期日期"),
                    from_on = table.Column<DateOnly>(type: "date", nullable: false, comment: "起始日期"),
                    to_on = table.Column<DateOnly>(type: "date", nullable: false, comment: "結束日期"),
                    auto_state = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "自動狀態(True:自動;False:手動)"),
                    state = table.Column<int>(type: "integer", nullable: false, comment: "狀態"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "金額"),
                    actual_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "實際金額"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    snapshot_vip_level = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "Snapshot Vip Level"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "更新時間"),
                    updated_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "更新使用者識別碼"),
                    updated_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "更新使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_cycle_forms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    type = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "日誌類型"),
                    before = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "之前"),
                    after = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "之後"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_logs", x => new { x.created_on, x.id });
                });

            migrationBuilder.CreateTable(
                name: "player_vip_level_upgrade_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    vip_level = table.Column<int>(type: "integer", nullable: false, comment: "Vip等級"),
                    auto_state = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "自動狀態(True:自動;False:手動)"),
                    state = table.Column<int>(type: "integer", nullable: false, comment: "狀態"),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "金額"),
                    actual_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, comment: "實際金額"),
                    remark = table.Column<string>(type: "text", nullable: false, defaultValue: "", comment: "備註"),
                    snapshot_vip_level = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'::jsonb", comment: "Snapshot Vip Level"),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "創建時間"),
                    created_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "創建使用者識別碼"),
                    created_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "創建使用者名稱"),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "更新時間"),
                    updated_user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "更新使用者識別碼"),
                    updated_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "", comment: "更新使用者名稱"),
                    repeat_times = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "重複次數")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_level_upgrade_forms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "player_vip_levels",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false, comment: "玩家代碼"),
                    vip_level_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"), comment: "VipLevel識別碼"),
                    vip_level = table.Column<int>(type: "integer", nullable: false, defaultValue: 1, comment: "VipLevel等級"),
                    auto_state = table.Column<int>(type: "integer", nullable: false, defaultValue: 0, comment: "自動狀態(0:啟用 1:停用)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_vip_levels", x => x.player_code);
                });

            migrationBuilder.CreateTable(
                name: "promotion_distribute_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "now()"),
                    distribute_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_distribute_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_distribute_plans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    condition_hash = table.Column<long>(type: "bigint", nullable: false),
                    detail = table.Column<string>(type: "jsonb", nullable: true),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_distribute_plans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_distributes",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket = table.Column<decimal>(type: "numeric", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    distributor = table.Column<string>(type: "text", nullable: true),
                    plan_id = table.Column<Guid>(type: "uuid", nullable: true),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference_id = table.Column<Guid>(type: "uuid", nullable: true),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_distributes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_groups",
                schema: "dbo",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    translate = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_groups", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "promotion_promote_deposit_channels",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric", nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    distribute_plan_id = table.Column<Guid>(type: "uuid", nullable: false),
                    form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vip_level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_promote_deposit_channels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_rebate_daily_statistics",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    settings = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'"),
                    total_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    report_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_rebate_daily_statistics", x => new { x.report_date, x.brand_id, x.promotion_id, x.player_code });
                });

            migrationBuilder.CreateTable(
                name: "promotion_rebate_distributes",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    distribute_date = table.Column<DateOnly>(type: "date", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    settings = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'"),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_rebate_distributes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_relief_daily_statistics",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    report_date = table.Column<DateOnly>(type: "date", nullable: false),
                    settings = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'"),
                    total_win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    report_date_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_relief_daily_statistics", x => new { x.report_date, x.brand_id, x.promotion_id, x.player_code });
                });

            migrationBuilder.CreateTable(
                name: "promotion_relief_distributes",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    distribute_date = table.Column<DateOnly>(type: "date", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    settings = table.Column<string>(type: "jsonb", nullable: false, defaultValueSql: "'{}'"),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_relief_distributes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "promotion_types",
                schema: "dbo",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    extend = table.Column<string>(type: "jsonb", nullable: true),
                    translate = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_types", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "resellers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    business_type = table.Column<short>(type: "smallint", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    operational_email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resellers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    display_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    is_root = table.Column<bool>(type: "boolean", nullable: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: true),
                    menu_setting = table.Column<string>(type: "jsonb", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: true),
                    role_type = table.Column<short>(type: "smallint", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "round_aggregates",
                schema: "report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: false),
                    hour = table.Column<int>(type: "integer", nullable: false),
                    minute = table.Column<int>(type: "integer", nullable: false),
                    original_turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    report_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    round_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_round_aggregate_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "round_operation_records",
                schema: "bet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    new_data = table.Column<string>(type: "jsonb", nullable: false),
                    old_data = table.Column<string>(type: "jsonb", nullable: false),
                    operator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    remark = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    round_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_round_operation_records", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rounds",
                schema: "bet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_status = table.Column<short>(type: "smallint", nullable: false),
                    closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    commission = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    currency_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    effective_betting_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    external_closed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    external_created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    external_round_id = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    reopened_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    reopen_turnover_adjustment = table.Column<decimal>(type: "numeric", nullable: true),
                    settle_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    tie_bet_adjustment = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    turnover = table.Column<decimal>(type: "numeric", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    valid_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rounds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                schema: "dbo",
                columns: table => new
                {
                    key = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_settings", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "sms_settings",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    setting = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    created_by = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    updated_by = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sms_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "social_media_settings",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    created_by = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    updated_by = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_social_media_settings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "station_letter_delivery_box",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    come_from = table.Column<Guid>(type: "uuid", nullable: true),
                    content = table.Column<string>(type: "text", nullable: false),
                    @operator = table.Column<string>(name: "operator", type: "text", nullable: false),
                    receiver = table.Column<string>(type: "text", nullable: true),
                    receiver_type = table.Column<string>(type: "text", nullable: false),
                    sender = table.Column<string>(type: "text", nullable: false),
                    sent_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_station_letter_delivery_box", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "station_letter2",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    come_from = table.Column<Guid>(type: "uuid", nullable: true),
                    content = table.Column<string>(type: "text", nullable: false),
                    have_read = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    quotation = table.Column<string>(type: "text", nullable: true),
                    received_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    receiver = table.Column<string>(type: "text", nullable: false),
                    replied = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    sender = table.Column<string>(type: "text", nullable: false),
                    sent_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_station_letter2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "system_localizations",
                schema: "dbo",
                columns: table => new
                {
                    culture_code = table.Column<string>(type: "text", nullable: false),
                    message_id = table.Column<string>(type: "text", nullable: false),
                    system_code = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_system_localizations", x => new { x.system_code, x.culture_code, x.message_id });
                });

            migrationBuilder.CreateTable(
                name: "systems",
                schema: "dbo",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_systems", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "vip_level_snapshots",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "識別碼"),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "平台識別碼"),
                    data = table.Column<string>(type: "jsonb", nullable: false, comment: "資料"),
                    effective_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "生效時間"),
                    snapshot_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, comment: "快照時間"),
                    snapshot_user_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "快照使用者識別碼"),
                    snapshot_username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "快照使用者名稱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vip_level_snapshots", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "withdraw_form_event_source",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    modify_user = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_withdraw_form_event_source", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_multiple_layers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    agent_dividend_id = table.Column<int>(type: "integer", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_dividend_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    actual_dividend_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    agent_covered_bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    agent_covered_bonus_adjust = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    dividend = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    dividend_provider_agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dividend_provider_id = table.Column<int>(type: "integer", nullable: false),
                    layer = table.Column<string>(type: "text", nullable: false),
                    agent_dividend_snapshot_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_multiple_layers_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_agents_dividends_agent_dividend_multiple_layers_agent_dividend_id",
                        column: x => x.agent_dividend_id,
                        principalSchema: "dbo",
                        principalTable: "agent_dividends",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_contract_conditions",
                schema: "dbo",
                columns: table => new
                {
                    brand_contract_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    dividend_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_contract_conditions_rank_brand_contract_id", x => new { x.rank, x.brand_contract_id });
                    table.ForeignKey(
                        name: "fk_brand_contract_conditions_brand_contract_brand_contract_id",
                        column: x => x.brand_contract_id,
                        principalSchema: "dbo",
                        principalTable: "brand_contracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    max_bet = table.Column<int>(type: "integer", nullable: false),
                    max_bet_per_match = table.Column<int>(type: "integer", nullable: false),
                    min_bet = table.Column<int>(type: "integer", nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bet_limits", x => x.id);
                    table.ForeignKey(
                        name: "fk_bet_limits_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallets",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    external_currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    locked_balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: true),
                    cash_type = table.Column<string>(type: "text", nullable: false, defaultValue: "Player"),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wallets", x => x.id);
                    table.ForeignKey(
                        name: "fk_wallets_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "game_action_batches",
                schema: "bet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    error = table.Column<short>(type: "smallint", nullable: false),
                    error_message = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    errors_json = table.Column<string>(type: "jsonb", nullable: true),
                    external_id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transactions_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_action_batches", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_action_batches_game_provider_configurations_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_provider_bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    external_setting = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    max_bet = table.Column<int>(type: "integer", nullable: false),
                    max_bet_per_match = table.Column<int>(type: "integer", nullable: true),
                    min_bet = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_bet_limits", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_provider_bet_limits_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "fk_game_provider_bet_limits_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_provider_configurations",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    client_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    configuration_data = table.Column<string>(type: "text", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    desktop_endpoint = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
                    mobile_endpoint = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    secret_key = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_configurations", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_provider_configurations_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_provider_currencies",
                schema: "dbo",
                columns: table => new
                {
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_provider_currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_currencies", x => new { x.game_provider_id, x.currency_code });
                    table.ForeignKey(
                        name: "fk_game_provider_currencies_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_provider_currencies_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "market_types",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    external_id = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_market_types", x => x.id);
                    table.UniqueConstraint("ak_market_types_game_provider_id_code", x => new { x.game_provider_id, x.code });
                    table.ForeignKey(
                        name: "fk_market_types_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sport_types",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    external_id = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sport_types", x => x.id);
                    table.UniqueConstraint("ak_sport_types_game_provider_id_code", x => new { x.game_provider_id, x.code });
                    table.ForeignKey(
                        name: "fk_sport_types_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sub_game_providers",
                schema: "dbo",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    localization = table.Column<string>(type: "jsonb", nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sub_game_providers", x => x.code);
                    table.ForeignKey(
                        name: "fk_sub_game_providers_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_provider_languages",
                schema: "dbo",
                columns: table => new
                {
                    culture_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_provider_culture_code = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_provider_languages", x => new { x.game_provider_id, x.culture_code });
                    table.ForeignKey(
                        name: "fk_game_provider_languages_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_provider_languages_languages_culture_code",
                        column: x => x.culture_code,
                        principalSchema: "dbo",
                        principalTable: "languages",
                        principalColumn: "culture_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "localized_strings",
                schema: "dbo",
                columns: table => new
                {
                    context = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    culture_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    key = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    translation = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localized_strings", x => new { x.key, x.culture_code, x.context });
                    table.ForeignKey(
                        name: "fk_localized_strings_languages_culture_code",
                        column: x => x.culture_code,
                        principalSchema: "dbo",
                        principalTable: "languages",
                        principalColumn: "culture_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_method_channels",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    channel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    method_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_method_channels", x => x.id);
                    table.UniqueConstraint("ak_payment_method_channels_payment_id_method_id_channed_id", x => new { x.payment_id, x.method_id, x.channel_id });
                    table.ForeignKey(
                        name: "fk_payment_method_channels_payment_channels_id",
                        column: x => x.channel_id,
                        principalSchema: "dbo",
                        principalTable: "payment_channels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_payment_method_channels_payment_methods_id",
                        column: x => x.method_id,
                        principalSchema: "dbo",
                        principalTable: "payment_methods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_payment_method_channels_payments_id",
                        column: x => x.payment_id,
                        principalSchema: "dbo",
                        principalTable: "payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "licensees",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    operational_email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    reference_id = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_licensees", x => x.id);
                    table.ForeignKey(
                        name: "fk_licensees_resellers_reseller_id",
                        column: x => x.reseller_id,
                        principalSchema: "dbo",
                        principalTable: "resellers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reseller_currencies",
                schema: "dbo",
                columns: table => new
                {
                    currency_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reseller_currencies", x => new { x.reseller_id, x.currency_code });
                    table.ForeignKey(
                        name: "fk_reseller_currencies_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reseller_currencies_resellers_reseller_id",
                        column: x => x.reseller_id,
                        principalSchema: "dbo",
                        principalTable: "resellers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reseller_game_providers",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reseller_game_providers", x => new { x.reseller_id, x.game_provider_id });
                    table.ForeignKey(
                        name: "fk_reseller_game_providers_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reseller_game_providers_game_resellers_reseller_id",
                        column: x => x.reseller_id,
                        principalSchema: "dbo",
                        principalTable: "resellers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reseller_languages",
                schema: "dbo",
                columns: table => new
                {
                    culture_code = table.Column<string>(type: "character varying(6)", nullable: false),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reseller_languages", x => new { x.reseller_id, x.culture_code });
                    table.ForeignKey(
                        name: "fk_reseller_languages_languages_culture_code",
                        column: x => x.culture_code,
                        principalSchema: "dbo",
                        principalTable: "languages",
                        principalColumn: "culture_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reseller_languages_resellers_reseller_id",
                        column: x => x.reseller_id,
                        principalSchema: "dbo",
                        principalTable: "resellers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "round_details",
                schema: "bet",
                columns: table => new
                {
                    round_id = table.Column<Guid>(type: "uuid", nullable: false),
                    additional_data = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_round_details", x => x.round_id);
                    table.ForeignKey(
                        name: "fk_round_details_rounds_round_id",
                        column: x => x.round_id,
                        principalSchema: "bet",
                        principalTable: "rounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "functions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    features = table.Column<string>(type: "jsonb", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_functions", x => x.id);
                    table.UniqueConstraint("ak_functions_name_system", x => new { x.name, x.system });
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groups", x => x.id);
                    table.UniqueConstraint("ak_groups_name_system", x => new { x.name, x.system });
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reseller_bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    bet_limit_id = table.Column<int>(type: "integer", nullable: false),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reseller_bet_limits", x => new { x.reseller_id, x.bet_limit_id });
                    table.ForeignKey(
                        name: "fk_reseller_bet_limits_resellers_bet_limit_id",
                        column: x => x.bet_limit_id,
                        principalSchema: "dbo",
                        principalTable: "bet_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reseller_bet_limits_resellers_reseller_id",
                        column: x => x.reseller_id,
                        principalSchema: "dbo",
                        principalTable: "resellers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_actions",
                schema: "bet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bet_type = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    closing_round_explicit_request = table.Column<bool>(type: "boolean", nullable: true),
                    external_bet_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    external_game_action_group_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    external_transaction_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    extra_data = table.Column<string>(type: "text", nullable: true),
                    game_action_batch_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_closing_round = table.Column<bool>(type: "boolean", nullable: false),
                    jackpot_contribution = table.Column<string>(type: "jsonb", nullable: true),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    player_ip = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    recorded_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    referenced_game_action_id = table.Column<Guid>(type: "uuid", nullable: true),
                    round_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    turnover = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    unsettled_bets = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    stored_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_actions", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_actions_game_action_batches_game_action_batch_id",
                        column: x => x.game_action_batch_id,
                        principalSchema: "bet",
                        principalTable: "game_action_batches",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_game_actions_referenced_game_action_id",
                        column: x => x.referenced_game_action_id,
                        principalSchema: "bet",
                        principalTable: "game_actions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_game_actions_rounds_round_id",
                        column: x => x.round_id,
                        principalSchema: "bet",
                        principalTable: "rounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sport_market_types",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    market_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sport_type_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sport_market_types", x => x.id);
                    table.UniqueConstraint("ak_sport_market_types_sport_type_id_market_type_id", x => new { x.sport_type_id, x.market_type_id });
                    table.ForeignKey(
                        name: "fk_sport_market_types_market_types_market_type_id",
                        column: x => x.market_type_id,
                        principalSchema: "dbo",
                        principalTable: "market_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sport_market_types_sport_types_sport_type_id",
                        column: x => x.sport_type_id,
                        principalSchema: "dbo",
                        principalTable: "sport_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "games",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    available_currencies = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false, defaultValue: ""),
                    available_to_brand = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    endpoint_path = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    external_id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    has_turnover_on_tie_bet = table.Column<bool>(type: "boolean", nullable: false),
                    html5 = table.Column<bool>(type: "boolean", nullable: false),
                    localization = table.Column<string>(type: "jsonb", nullable: true),
                    platform_type = table.Column<byte>(type: "smallint", nullable: false),
                    rule_url = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    sub_game = table.Column<bool>(type: "boolean", nullable: false),
                    sub_game_provider_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_games", x => x.id);
                    table.ForeignKey(
                        name: "fk_games_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_games_sub_game_providers_sub_game_provider_code",
                        column: x => x.sub_game_provider_code,
                        principalSchema: "dbo",
                        principalTable: "sub_game_providers",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_dividend_type = table.Column<short>(type: "smallint", nullable: false),
                    api_key = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    auto_clear_wagering_requirement = table.Column<bool>(type: "boolean", nullable: false),
                    auto_clear_wagering_requirement_balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    auto_sent_agent_bonus = table.Column<bool>(type: "boolean", nullable: false),
                    auto_sent_player_bonus = table.Column<bool>(type: "boolean", nullable: false),
                    check_dividend_active_count = table.Column<bool>(type: "boolean", nullable: false),
                    client_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    current_settlement_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    current_settlement_to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deposit_handling_fee_rate_ten_percentile = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    deposit_payment_lock_enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    enable_agent_sms = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    enable_bank_info_register_flow = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    enable_email_register_flow = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    enable_player_identity = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    enable_sms = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    enable_sms_register_flow = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    logo_info = table.Column<string>(type: "jsonb", nullable: true),
                    next_settlement_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    next_settlement_to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    operational_email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    platform_charge = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    player_register_flow_settings = table.Column<string>(type: "jsonb", nullable: true),
                    previous_settlement_from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    previous_settlement_to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    secret_key = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    settlement_day = table.Column<int>(type: "integer", nullable: true),
                    settlement_interval_type = table.Column<short>(type: "smallint", nullable: false),
                    sms_vendor_code = table.Column<string>(type: "text", nullable: true),
                    sms_vendor_settings = table.Column<string>(type: "jsonb", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    time_span_minutes = table.Column<int>(type: "integer", nullable: true, defaultValue: 480),
                    time_zone_id = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    withdraw_handling_fee_rate_ten_percentile = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    enable_player_agent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    enable_platform_account_fund_check = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brands", x => x.id);
                    table.ForeignKey(
                        name: "fk_brands_licensees_licensee_id",
                        column: x => x.licensee_id,
                        principalSchema: "dbo",
                        principalTable: "licensees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "licensee_bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    bet_limit_id = table.Column<int>(type: "integer", nullable: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_licensee_bet_limits", x => new { x.licensee_id, x.bet_limit_id });
                    table.ForeignKey(
                        name: "fk_licensee_bet_limits_bet_limits_bet_limit_id",
                        column: x => x.bet_limit_id,
                        principalSchema: "dbo",
                        principalTable: "bet_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_licensee_bet_limits_licensees_licensee_id",
                        column: x => x.licensee_id,
                        principalSchema: "dbo",
                        principalTable: "licensees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "licensee_currencies",
                schema: "dbo",
                columns: table => new
                {
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_licensee_currencies", x => new { x.licensee_id, x.currency_code });
                    table.ForeignKey(
                        name: "fk_licensee_currencies_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_licensee_currencies_licensees_licensee_id",
                        column: x => x.licensee_id,
                        principalSchema: "dbo",
                        principalTable: "licensees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "licensee_game_providers",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_licensee_game_providers", x => new { x.licensee_id, x.game_provider_id });
                    table.ForeignKey(
                        name: "fk_licensee_game_providers_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_licensee_game_providers_licensees_licensee_id",
                        column: x => x.licensee_id,
                        principalSchema: "dbo",
                        principalTable: "licensees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "licensee_languages",
                schema: "dbo",
                columns: table => new
                {
                    culture_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_licensee_languages", x => new { x.licensee_id, x.culture_code });
                    table.ForeignKey(
                        name: "fk_licensee_languages_languages_culture_code",
                        column: x => x.culture_code,
                        principalSchema: "dbo",
                        principalTable: "languages",
                        principalColumn: "culture_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_licensee_languages_licensees_licensee_id",
                        column: x => x.licensee_id,
                        principalSchema: "dbo",
                        principalTable: "licensees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "function_event_sources",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    change_sets = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    function_id = table.Column<Guid>(type: "uuid", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_function_event_sources", x => x.id);
                    table.ForeignKey(
                        name: "fk_functions",
                        column: x => x.function_id,
                        principalSchema: "dbo",
                        principalTable: "functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    function_id = table.Column<Guid>(type: "uuid", nullable: false),
                    identity = table.Column<string>(type: "text", nullable: false),
                    identity_type = table.Column<string>(type: "text", nullable: false),
                    order = table.Column<int>(type: "integer", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    fk_functions = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_permissions_functions_function_id",
                        column: x => x.fk_functions,
                        principalSchema: "dbo",
                        principalTable: "functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "group_users",
                schema: "dbo",
                columns: table => new
                {
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    system = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group_users", x => new { x.group_id, x.user_id, x.system });
                    table.ForeignKey(
                        name: "fk_groups",
                        column: x => x.group_id,
                        principalSchema: "dbo",
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_systems",
                        column: x => x.system,
                        principalSchema: "dbo",
                        principalTable: "systems",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agents",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_status = table.Column<int>(type: "integer", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_game_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    commission_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_by_username = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    default_wallet_id = table.Column<Guid>(type: "uuid", nullable: false),
                    dividend_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    invitation_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    level_type = table.Column<int>(type: "integer", nullable: false),
                    live_dealer_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    parent_agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    path = table.Column<string>(type: "ltree", nullable: false),
                    phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    qq = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    real_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    registered_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    slot_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    updated_by_username = table.Column<string>(type: "text", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    virtual_sports_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    wechat = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    withdraw_password = table.Column<byte[]>(type: "bytea", nullable: false),
                    withdraw_salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    snapshot_event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: true),
                    negative_agent_dividend_carry_forward = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agents", x => x.id);
                    table.ForeignKey(
                        name: "fk_agents_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_agents_parent_agent_id",
                        column: x => x.parent_agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "announcements",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "character varying(8000)", maxLength: 8000, nullable: true),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    display_order = table.Column<short>(type: "smallint", nullable: false),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    localization = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}"),
                    remarks = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    subject = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false, defaultValue: "Marquee"),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    verified_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_announcements", x => x.id);
                    table.ForeignKey(
                        name: "fk_announcements_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "article_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    localized_articles = table.Column<string>(type: "jsonb", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    modifier = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_article_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_article_forms_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "banners",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    begin_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_user_name = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()"),
                    display_order = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    end_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    is_enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    localization = table.Column<string>(type: "jsonb", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    title = table.Column<string>(type: "text", nullable: false),
                    updated_by_user_name = table.Column<string>(type: "text", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_banners", x => x.id);
                    table.ForeignKey(
                        name: "fk_banners_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_agent_dividend_conditions",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    dividend_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_agent_dividend_conditions_rank_brand_id", x => new { x.rank, x.brand_id });
                    table.ForeignKey(
                        name: "fk_brand_agent_dividend_conditions_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    bet_limit_id = table.Column<int>(type: "integer", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_bet_limits", x => new { x.brand_id, x.bet_limit_id });
                    table.ForeignKey(
                        name: "fk_brand_bet_limits_bet_limits_bet_limit_id",
                        column: x => x.bet_limit_id,
                        principalSchema: "dbo",
                        principalTable: "bet_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_bet_limits_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_bucket_types",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_types = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_bucket_types", x => x.brand_id);
                    table.ForeignKey(
                        name: "fk_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_communications",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    app_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    qr_code_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_communications", x => x.id);
                    table.ForeignKey(
                        name: "fk_brand_communications_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_currencies",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    brand_currency_code = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_currencies", x => new { x.brand_id, x.currency_code });
                    table.ForeignKey(
                        name: "fk_brand_currencies_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_currencies_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_domains",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    url = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_domains", x => x.id);
                    table.ForeignKey(
                        name: "fk_brand_domains_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_game_providers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    default_language_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    desktop_query_string = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false, defaultValue: ""),
                    game_provider_configuration_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_manual_change_status = table.Column<bool>(type: "boolean", nullable: false),
                    mobile_query_string = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false, defaultValue: ""),
                    status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_providers", x => x.id);
                    table.ForeignKey(
                        name: "fk_brand_game_providers_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_game_providers_game_provider_configurations_game_provider_configuration_id",
                        column: x => x.game_provider_configuration_id,
                        principalSchema: "dbo",
                        principalTable: "game_provider_configurations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_brand_game_providers_game_providers_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_brand_game_providers_languages_default_language_code",
                        column: x => x.default_language_code,
                        principalSchema: "dbo",
                        principalTable: "languages",
                        principalColumn: "culture_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_games",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    display_order = table.Column<int>(type: "integer", nullable: false),
                    effective_betting_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    rebate = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    tag = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_games", x => x.id);
                    table.UniqueConstraint("ak_brand_games_brand_id_game_id", x => new { x.brand_id, x.game_id });
                    table.ForeignKey(
                        name: "fk_brand_games_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_games_games_game_id",
                        column: x => x.game_id,
                        principalSchema: "dbo",
                        principalTable: "games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_groups",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_sports = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_groups", x => x.id);
                    table.ForeignKey(
                        name: "fk_brand_groups_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_languages",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    culture_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    brand_culture_code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_languages", x => new { x.brand_id, x.culture_code });
                    table.ForeignKey(
                        name: "fk_brand_languages_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_languages_languages_culture_code",
                        column: x => x.culture_code,
                        principalSchema: "dbo",
                        principalTable: "languages",
                        principalColumn: "culture_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_live_chats",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    chat_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    chat_setting = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_live_chats", x => x.brand_id);
                    table.ForeignKey(
                        name: "fk_brand_live_chats_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_maintenance",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    begin_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_maintenance", x => x.id);
                    table.ForeignKey(
                        name: "fk_brand_maintenance_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_payment_settings",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_bank_info_count_limit = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_settings", x => x.brand_id);
                    table.ForeignKey(
                        name: "fk_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_payments",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    all_players = table.Column<bool>(type: "boolean", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    channel_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()"),
                    deposited_amount_max = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposited_amount_min = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    deposited_amount_unlimited = table.Column<bool>(type: "boolean", nullable: false),
                    display_order = table.Column<int>(type: "integer", nullable: false),
                    extended_data = table.Column<string>(type: "jsonb", nullable: false),
                    handling_fee_rate_ten_percentile = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    identity_authentication = table.Column<bool>(type: "boolean", nullable: false),
                    payment_method_channel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_status = table.Column<int>(type: "integer", nullable: false),
                    phone_authentication = table.Column<bool>(type: "boolean", nullable: false),
                    player_list_condition = table.Column<int>(type: "integer", nullable: false),
                    reason = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    reduce_player_amount = table.Column<bool>(type: "boolean", nullable: false),
                    transfer_limit_from = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    transfer_limit_to = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    transfer_type = table.Column<int>(type: "integer", nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_brand_payments_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_payments_payment_method_channels_id",
                        column: x => x.payment_method_channel_id,
                        principalSchema: "dbo",
                        principalTable: "payment_method_channels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: true),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                    table.ForeignKey(
                        name: "fk_departments_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_departments_licensees_licensee_id",
                        column: x => x.licensee_id,
                        principalSchema: "dbo",
                        principalTable: "licensees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_departments_resellers_reseller_id",
                        column: x => x.reseller_id,
                        principalSchema: "dbo",
                        principalTable: "resellers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "draft_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    localized_articles = table.Column<string>(type: "jsonb", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    modifier = table.Column<string>(type: "text", nullable: false),
                    publish_date = table.Column<DateOnly>(type: "date", nullable: true),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    updated_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_draft_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_draft_forms_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payment_handling_fees",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    approved_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    fee = table.Column<decimal>(type: "numeric", nullable: false),
                    form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    recorded_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    remark = table.Column<string>(type: "jsonb", nullable: true),
                    type = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    user_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_handling_fees_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_payment_handling_fees_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "platform_credits",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    credit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_platform_credits", x => x.id);
                    table.ForeignKey(
                        name: "fk_platform_credits_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "station_letters",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_all_players = table.Column<bool>(type: "boolean", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    localization = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}"),
                    remarks = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false),
                    subject = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    verified_by_username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_station_letters", x => x.id);
                    table.ForeignKey(
                        name: "fk_station_letters_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    external_transaction_id = table.Column<string>(type: "text", nullable: true),
                    lock_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    locked_balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    player_code = table.Column<string>(type: "text", nullable: false),
                    recorded_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_transactions_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_transactions_wallets_wallet_id",
                        column: x => x.wallet_id,
                        principalSchema: "dbo",
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transfer_balance_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    created_user_id = table.Column<string>(type: "text", nullable: false),
                    drawee = table.Column<string>(type: "text", nullable: false),
                    drawee_type = table.Column<string>(type: "text", nullable: false),
                    include_in_net_profit = table.Column<bool>(type: "boolean", nullable: false),
                    payee = table.Column<string>(type: "text", nullable: false),
                    payee_type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transfer_balance_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_transfer_balance_forms_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vip_levels",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    birth_reward = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_game_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    level_keep_accumulate_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    level_keep_accumulate_deposit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    level_keep_condition = table.Column<bool>(type: "boolean", nullable: false),
                    level_up_accumulate_bet_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    level_up_accumulate_deposit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    live_dealer_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    lottery_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    promotion_reward = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    quarterly_reward = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    slot_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    sports_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    virtual_sports_rebate_percentage = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    withdraw_total_amount_per_day = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValueSql: "-1"),
                    withdraw_transactions_per_day = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "-1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vip_levels", x => x.id);
                    table.ForeignKey(
                        name: "fk_vip_levels_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "whitelists",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    internal_note = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ip_address = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    licensee_id = table.Column<Guid>(type: "uuid", nullable: true),
                    reseller_id = table.Column<Guid>(type: "uuid", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_whitelists", x => x.id);
                    table.ForeignKey(
                        name: "fk_whitelists_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_whitelists_licensees_licensee_id",
                        column: x => x.licensee_id,
                        principalSchema: "dbo",
                        principalTable: "licensees",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_whitelists_resellers_reseller_id",
                        column: x => x.reseller_id,
                        principalSchema: "dbo",
                        principalTable: "resellers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "agent_audit_logs",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    operation = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_audit_logs", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_audit_logs_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agent_banks",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank_account = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    bank_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_by_username = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    real_name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_by_username = table.Column<string>(type: "text", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_banks", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_banks_agents_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agent_dividend_conditions",
                schema: "dbo",
                columns: table => new
                {
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rank = table.Column<int>(type: "integer", nullable: false),
                    contract_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000")),
                    active_number = table.Column<int>(type: "integer", nullable: false),
                    dividend_percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    net_profit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    win_loss_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_dividend_conditions_rank_agent_id", x => new { x.rank, x.agent_id });
                    table.ForeignKey(
                        name: "fk_agents_dividend_conditions_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agent_domains",
                schema: "dbo",
                columns: table => new
                {
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    domain_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_domains", x => new { x.agent_id, x.domain_name });
                    table.ForeignKey(
                        name: "fk_agent_domains_agents_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agent_login_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    expired_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ip_address = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_login_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_login_records_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_agent_login_records_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "agent_wallets",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_wallets", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_wallet_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_agent_wallets_currencies_currency_code",
                        column: x => x.currency_code,
                        principalSchema: "dbo",
                        principalTable: "currencies",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "brand_game_provider_schedules",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_of_week = table.Column<int>(type: "integer", nullable: true),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_game_provider_schedule", x => x.id);
                    table.ForeignKey(
                        name: "fk_brand_game_provider_schedule_brand_game_providers_id",
                        column: x => x.brand_game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "brand_game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_group_bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bet_limit_id = table.Column<int>(type: "integer", nullable: false),
                    brand_group_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_group_bet_limits", x => x.id);
                    table.UniqueConstraint("ak_brand_group_bet_limits_brand_group_id_bet_limit_id", x => new { x.brand_group_id, x.bet_limit_id });
                    table.ForeignKey(
                        name: "fk_brand_group_bet_limits_bet_limits_bet_limit_id",
                        column: x => x.bet_limit_id,
                        principalSchema: "dbo",
                        principalTable: "bet_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_group_bet_limits_brand_groups_brand_group_id",
                        column: x => x.brand_group_id,
                        principalSchema: "dbo",
                        principalTable: "brand_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_group_games",
                schema: "dbo",
                columns: table => new
                {
                    brand_game_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_group_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_group_games", x => new { x.brand_group_id, x.brand_game_id });
                    table.ForeignKey(
                        name: "fk_brand_group_games_brand_games_brand_game_id",
                        column: x => x.brand_game_id,
                        principalSchema: "dbo",
                        principalTable: "brand_games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_group_games_brand_groups_brand_group_id",
                        column: x => x.brand_group_id,
                        principalSchema: "dbo",
                        principalTable: "brand_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "withdraw_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    actual_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    apply_info = table.Column<string>(type: "jsonb", nullable: true),
                    bank_info = table.Column<string>(type: "jsonb", nullable: false),
                    bank_info_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_payment_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()"),
                    handling_fee = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    order_no = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    paid_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    paid_user_id = table.Column<string>(type: "text", nullable: true),
                    paid_user_name = table.Column<string>(type: "text", nullable: true),
                    payment_return = table.Column<string>(type: "jsonb", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true),
                    player_remark = table.Column<string>(type: "text", nullable: true),
                    reviewed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    reviewed_user_id = table.Column<string>(type: "text", nullable: true),
                    reviewed_user_name = table.Column<string>(type: "text", nullable: true),
                    snapshot_event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    third_party_order_no = table.Column<string>(type: "text", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()"),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    user_type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_withdraw_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_withdraw_forms_brand_payments_brand_payment_id",
                        column: x => x.brand_payment_id,
                        principalSchema: "dbo",
                        principalTable: "brand_payments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_withdraw_forms_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    last_login_ip = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    last_login_time = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    time_zone = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_departments_department_id",
                        column: x => x.department_id,
                        principalSchema: "dbo",
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_users_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "dbo",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "platform_pay_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    pay_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    platform_credit_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_platform_pay_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_platform_credits_brand_quotas_id",
                        column: x => x.platform_credit_id,
                        principalSchema: "dbo",
                        principalTable: "platform_credits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_payment_vip_levels",
                schema: "dbo",
                columns: table => new
                {
                    brand_payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vip_level_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_vip_levels", x => new { x.brand_payment_id, x.vip_level_id });
                    table.ForeignKey(
                        name: "fk_brand_payment_vip_levels_brand_payments_brand_payment_id",
                        column: x => x.brand_payment_id,
                        principalSchema: "dbo",
                        principalTable: "brand_payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_payment_vip_levels_vip_levels_vip_level_id",
                        column: x => x.vip_level_id,
                        principalSchema: "dbo",
                        principalTable: "vip_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "players",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    accumulated_deposit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: true),
                    area_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    bet_limit_id = table.Column<int>(type: "integer", nullable: false),
                    birthdate = table.Column<DateOnly>(type: "Date", nullable: true),
                    birthday = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true, computedColumnSql: "lpad(extract('month' from birthdate)::text,2,'0') || lpad(extract('day' from birthdate)::text,2,'0')", stored: true),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    default_wallet_currency_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    default_wallet_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    first_deposit_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    first_promotion_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    identity_authentication = table.Column<bool>(type: "boolean", nullable: false),
                    id_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    last_active_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    phone = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    phone_authentication = table.Column<bool>(type: "boolean", nullable: false),
                    qq = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    real_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    registered_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    snapshot_event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    type = table.Column<byte>(type: "smallint", nullable: false),
                    updated_by_username = table.Column<string>(type: "text", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    vip_id = table.Column<Guid>(type: "uuid", nullable: true),
                    wechat = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    withdraw_password = table.Column<byte[]>(type: "bytea", nullable: false),
                    withdraw_salt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_code", x => x.player_code);
                    table.ForeignKey(
                        name: "fk_players_agents_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_players_bet_limits_bet_limit_id",
                        column: x => x.bet_limit_id,
                        principalSchema: "dbo",
                        principalTable: "bet_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_players_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_players_vip_levels_vip_id",
                        column: x => x.vip_id,
                        principalSchema: "dbo",
                        principalTable: "vip_levels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "promotions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount_used = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    amount_used_snapshot_id = table.Column<Guid>(type: "uuid", nullable: true),
                    auto_sent_player_bonus = table.Column<bool>(type: "boolean", nullable: false),
                    bonus_amount_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    campaign_detail = table.Column<string>(type: "jsonb", nullable: false, defaultValue: "{}"),
                    content = table.Column<string>(type: "text", nullable: true),
                    created_by_username = table.Column<string>(type: "text", nullable: true),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    desktop_banner = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    display_order = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: true),
                    localization = table.Column<string>(type: "jsonb", nullable: true),
                    mobile_banner = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    promotion_type = table.Column<string>(type: "text", nullable: false),
                    settlement_interval_type = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    sub_subject = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    terms = table.Column<string>(type: "text", nullable: true),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    total_amount_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    turnover_multiple = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    unlimited = table.Column<short>(type: "smallint", nullable: false),
                    updated_by_username = table.Column<string>(type: "text", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    snapshot_event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    vip_level_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotions_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_promotions_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promotions_vip_levels_vip_level_id",
                        column: x => x.vip_level_id,
                        principalSchema: "dbo",
                        principalTable: "vip_levels",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "agent_transactions",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    external_transaction_id = table.Column<string>(type: "text", nullable: true),
                    lock_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    locked_balance = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    recorded_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_transaction_wallet_id",
                        column: x => x.wallet_id,
                        principalSchema: "dbo",
                        principalTable: "agent_wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_agent_transactions_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brand_group_game_provider_bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    brand_group_bet_limit_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_provider_bet_limit_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_group_game_provider_bet_limits", x => new { x.brand_group_bet_limit_id, x.game_provider_bet_limit_id });
                    table.ForeignKey(
                        name: "fk_brand_group_game_provider_bet_limits_brand_group_bet_limits_brand_group_bet_limit_id",
                        column: x => x.brand_group_bet_limit_id,
                        principalSchema: "dbo",
                        principalTable: "brand_group_bet_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_group_game_provider_bet_limits_game_provider_bet_limits_game_provider_bet_limit_id",
                        column: x => x.game_provider_bet_limit_id,
                        principalSchema: "dbo",
                        principalTable: "game_provider_bet_limits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agent_bank_infos",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank_type = table.Column<string>(type: "text", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    detail = table.Column<string>(type: "jsonb", nullable: true),
                    payment_channel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: true),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agent_bank_infos", x => x.id);
                    table.ForeignKey(
                        name: "fk_agent_bank_infos_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_agent_bank_infos_payment_channels_payment_channel_id",
                        column: x => x.payment_channel_id,
                        principalSchema: "dbo",
                        principalTable: "payment_channels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_agent_bank_infos_players_player_temp_id",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code");
                });

            migrationBuilder.CreateTable(
                name: "brand_payment_players",
                schema: "dbo",
                columns: table => new
                {
                    brand_payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    list_type = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brand_payment_players", x => new { x.brand_payment_id, x.player_code });
                    table.ForeignKey(
                        name: "fk_brand_payment_players_brand_payments_brand_payment_id",
                        column: x => x.brand_payment_id,
                        principalSchema: "dbo",
                        principalTable: "brand_payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_brand_payment_players_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deposit_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    actual_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: true),
                    amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    apply_info = table.Column<string>(type: "jsonb", nullable: true),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()"),
                    handling_fee = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    order_no = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    payment_return = table.Column<string>(type: "jsonb", nullable: true),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: true),
                    promotion_player_id = table.Column<int>(type: "integer", nullable: true),
                    remark = table.Column<string>(type: "text", nullable: true),
                    reviewed_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    reviewed_user_id = table.Column<string>(type: "text", nullable: true),
                    reviewed_user_name = table.Column<string>(type: "text", nullable: true),
                    snapshot_event_id = table.Column<Guid>(type: "uuid", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    third_party_order_no = table.Column<string>(type: "text", nullable: true),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deposit_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_deposit_forms_brand_payments_id",
                        column: x => x.brand_payment_id,
                        principalSchema: "dbo",
                        principalTable: "brand_payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_deposit_forms_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_deposit_froms_brands_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "game_player_transform_idnlive",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'10000001', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    configuration = table.Column<string>(type: "jsonb", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    player_code = table.Column<string>(type: "character varying", nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_game_player_transform_idnlive", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_player_transform_idnlive_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_agent_relations",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    agent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_agent_relations_player_code", x => x.player_code);
                    table.ForeignKey(
                        name: "fk_player_agents_agents_agent_id",
                        column: x => x.agent_id,
                        principalSchema: "dbo",
                        principalTable: "agents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_agents_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_agents_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_bank_infos",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank_info_hash = table.Column<byte[]>(type: "bytea", nullable: true),
                    bank_type = table.Column<string>(type: "text", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    @default = table.Column<bool>(name: "default", type: "boolean", nullable: false, defaultValue: false),
                    detail = table.Column<string>(type: "jsonb", nullable: true),
                    payment_channel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    updated_by_username = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    updated_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bank_infos", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_bank_infos_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_bank_infos_payment_channels_payment_channel_id",
                        column: x => x.payment_channel_id,
                        principalSchema: "dbo",
                        principalTable: "payment_channels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_bank_infos_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_bankinfo_attributions",
                schema: "dbo",
                columns: table => new
                {
                    bank_info_hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bankinfo_attributions", x => new { x.brand_id, x.bank_info_hash });
                    table.ForeignKey(
                        name: "fk_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_clean_forms",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket_anchor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cleaning_balance = table.Column<decimal>(type: "numeric", nullable: true),
                    cleaning_bucket_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    clear_wagering_requirement_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    current_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    current_bucket_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    deposit_form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_balance_return = table.Column<string>(type: "jsonb", nullable: true),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_clean_forms", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_brands",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_players",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_bucket_clean_forms2",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cleaning_balance = table.Column<decimal>(type: "numeric", nullable: true),
                    cleaning_bucket_amounts = table.Column<string>(type: "jsonb", nullable: true),
                    clear_wagering_requirement_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    current_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    current_bucket_amounts = table.Column<string>(type: "jsonb", nullable: false),
                    deposit_form_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_balance_return = table.Column<string>(type: "jsonb", nullable: true),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    snapshot_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    wallet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bucket_clean_forms2", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_brands2",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_bucket_clean_forms_players2",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_favorite_games",
                schema: "dbo",
                columns: table => new
                {
                    game_id = table.Column<int>(type: "integer", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    game_type = table.Column<int>(type: "integer", nullable: false),
                    sub_game_provider_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_favorite_games", x => new { x.player_code, x.game_id });
                    table.ForeignKey(
                        name: "fk_player_favorite_games_brand_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_favorite_games_player_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_game_settings",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    is_auto_transfer_to_game = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_game_settings", x => x.player_code);
                    table.ForeignKey(
                        name: "fk_player_game_settings_players",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_identity",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    player_authentication_form_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_identity", x => x.player_code);
                    table.ForeignKey(
                        name: "fk_player_identity_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_ip_records",
                schema: "dbo",
                columns: table => new
                {
                    ip_type = table.Column<short>(type: "smallint", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    host = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ip = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    record_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "Now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_ip_records", x => new { x.player_code, x.ip_type });
                    table.ForeignKey(
                        name: "fk_player_ip_records_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_login_records",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    expired_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ip_address = table.Column<string>(type: "text", nullable: true),
                    platform_type = table.Column<short>(type: "smallint", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_login_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_player_login_records_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_player_login_records_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "player_properties",
                schema: "dbo",
                columns: table => new
                {
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    value = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_properties", x => new { x.brand_id, x.player_code, x.name });
                    table.ForeignKey(
                        name: "fk_brand_player_property_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_player_property_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_sports_bet_limits",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    sport_market_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    max_bet = table.Column<int>(type: "integer", nullable: false),
                    max_bet_per_match = table.Column<int>(type: "integer", nullable: false),
                    min_bet = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_sports_bet_limits", x => new { x.player_code, x.sport_market_type_id });
                    table.ForeignKey(
                        name: "fk_player_sports_bet_limits_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_player_sports_bet_limits_sport_market_types_sport_market_type_id",
                        column: x => x.sport_market_type_id,
                        principalSchema: "dbo",
                        principalTable: "sport_market_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "station_letter_players",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    station_letter_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    read_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_station_letter_players", x => new { x.station_letter_id, x.player_code });
                    table.ForeignKey(
                        name: "fk_station_letter_players_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_station_letter_players_station_letters_station_letter_id",
                        column: x => x.station_letter_id,
                        principalSchema: "dbo",
                        principalTable: "station_letters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deposit_accumulate_roulette_events",
                schema: "dbo",
                columns: table => new
                {
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    roulette_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    total_deposit_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deposit_accumulate_roulette_events", x => new { x.player_code, x.promotion_id, x.date });
                    table.ForeignKey(
                        name: "fk_deposit_accumulate_roulette_events_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_deposit_accumulate_roulette_events_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_deposit_accumulate_roulette_events_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deposit_accumulate_roulette_game_events",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket = table.Column<decimal>(type: "numeric", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    item_index = table.Column<int>(type: "integer", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    roulette_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deposit_accumulate_roulette_game_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_game_events_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_events_players_brand_id",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_game_events_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "distribute_register_events",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_distribute_register_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_distribute_register_events_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_distribute_register_events_players_brand_id",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_distribute_register_events_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offline_login_reward_events",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bucket = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    logged_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offline_login_reward_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_offline_login_reward_events_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offline_login_reward_events_players_brand_id",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_offline_login_reward_events_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "promotion_bonuses",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus_amount_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    detail = table.Column<string>(type: "jsonb", nullable: true),
                    from = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    game_type = table.Column<short>(type: "smallint", nullable: true),
                    percentage = table.Column<decimal>(type: "numeric(9,6)", precision: 9, scale: 6, nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    promotion_type = table.Column<string>(type: "text", nullable: false),
                    to = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    total_amount_limit = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    turnover_multiple = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_bonus_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_promotion_bonus_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "promotion_game_providers",
                schema: "dbo",
                columns: table => new
                {
                    game_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_game_providers", x => new { x.promotion_id, x.game_provider_id });
                    table.ForeignKey(
                        name: "fk_promotion_game_provider_game_provider_id",
                        column: x => x.game_provider_id,
                        principalSchema: "dbo",
                        principalTable: "game_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promotion_game_provider_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "promotion_participants",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: true),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_participants_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_promotion_participant_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code");
                    table.ForeignKey(
                        name: "fk_promotion_participant_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "promotion_vip_levels",
                schema: "dbo",
                columns: table => new
                {
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vip_level_id = table.Column<Guid>(type: "uuid", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_vip_levels", x => new { x.promotion_id, x.vip_level_id });
                    table.ForeignKey(
                        name: "fk_promotion_vip_level_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promotion_vip_level_vip_level_id",
                        column: x => x.vip_level_id,
                        principalSchema: "dbo",
                        principalTable: "vip_levels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rebate_promotion_join_players",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rebate_promotion_join_players", x => new { x.promotion_id, x.player_code });
                    table.ForeignKey(
                        name: "fk_players_rebate_promotion_join_players",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promotions_rebate_promotion_join_players",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relief_promotion_join_players",
                schema: "dbo",
                columns: table => new
                {
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_relief_promotion_join_players", x => new { x.promotion_id, x.player_code });
                    table.ForeignKey(
                        name: "fk_players_rebate_promotion_join_players",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promotions_rebate_promotion_join_players",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roulette_sign_in_events",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bonus = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false, defaultValue: 0m),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    item_index = table.Column<int>(type: "integer", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roulette_sign_in_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_roulette_sign_in_events_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_roulette_sign_in_events_players_brand_id",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_roulette_sign_in_events_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sign_in_events",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    combo = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    created_on = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValueSql: "Now()"),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sign_in_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_sign_in_events_brands_brand_id",
                        column: x => x.brand_id,
                        principalSchema: "dbo",
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sign_in_events_players_brand_id",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sign_in_events_promotions_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaction_promotions",
                schema: "dbo",
                columns: table => new
                {
                    promotion_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transaction_id = table.Column<Guid>(type: "uuid", nullable: false),
                    promotion_bonus_id = table.Column<Guid>(type: "uuid", nullable: false),
                    promotion_type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transaction_promotions", x => new { x.transaction_id, x.promotion_id });
                    table.ForeignKey(
                        name: "fk_transaction_promotion_promotion_id",
                        column: x => x.promotion_id,
                        principalSchema: "dbo",
                        principalTable: "promotions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_bank_info_tags",
                schema: "dbo",
                columns: table => new
                {
                    bank_info_id = table.Column<Guid>(type: "uuid", nullable: false),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tag_type = table.Column<string>(type: "text", nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    tag = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_player_bank_info_tags", x => new { x.brand_id, x.bank_info_id, x.tag_type });
                    table.ForeignKey(
                        name: "fk_player_bank_info_tags_player_bank_infos_bank_info_id",
                        column: x => x.bank_info_id,
                        principalSchema: "dbo",
                        principalTable: "player_bank_infos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_player_bank_info_tags_players_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "promotion_players",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bonus_amount = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    bucket_amount_by_manual = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    player_code = table.Column<string>(type: "character varying(16)", nullable: false),
                    promotion_bonus_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sent_by_username = table.Column<string>(type: "text", nullable: true),
                    sent_on = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_promotion_player_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_promotion_bonus_player_code",
                        column: x => x.player_code,
                        principalSchema: "dbo",
                        principalTable: "players",
                        principalColumn: "player_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_promotion_bonus_promotion_brand_id",
                        column: x => x.promotion_bonus_id,
                        principalSchema: "dbo",
                        principalTable: "promotion_bonuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_adjust_agent_record_multiple_keys",
                schema: "dbo",
                table: "adjust_agent_records",
                columns: new[] { "created_on", "brand_id", "agent_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_adjust_player_record_multiple_keys",
                schema: "dbo",
                table: "adjust_player_records",
                columns: new[] { "created_on", "brand_id", "player_code", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_adjust_transfer_record_multiple_keys",
                schema: "dbo",
                table: "adjust_transfer_records",
                columns: new[] { "created_on", "transfer_type", "transfer_from_username", "transfer_to_username" });

            migrationBuilder.CreateIndex(
                name: "ix_agent_audit_logs_agent_id",
                schema: "dbo",
                table: "agent_audit_logs",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_bank_infos_agent_id",
                schema: "dbo",
                table: "agent_bank_infos",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_bank_infos_brand_id",
                schema: "dbo",
                table: "agent_bank_infos",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_bank_infos_payment_channel_id",
                schema: "dbo",
                table: "agent_bank_infos",
                column: "payment_channel_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_bank_infos_player_code",
                schema: "dbo",
                table: "agent_bank_infos",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_agent_bankers_agent_id",
                schema: "dbo",
                table: "agent_banks",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_conditions_agent_id",
                schema: "dbo",
                table: "agent_dividend_conditions",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_multiple_layers_agent_dividend_id",
                schema: "dbo",
                table: "agent_dividend_multiple_layers",
                column: "agent_dividend_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_multiple_layers_agent_id_dividend_provider_agent_id",
                schema: "dbo",
                table: "agent_dividend_multiple_layers",
                columns: new[] { "agent_id", "dividend_provider_agent_id" });

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_product_fees_agent_dividend_id",
                schema: "dbo",
                table: "agent_dividend_product_fees",
                column: "agent_dividend_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividend_records_brand_id_agent_id",
                schema: "dbo",
                table: "agent_dividend_records",
                columns: new[] { "brand_id", "agent_id" });

            migrationBuilder.CreateIndex(
                name: "ux_agent_dividend_records",
                schema: "dbo",
                table: "agent_dividend_records",
                column: "agent_dividend_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividends_agent_id_brand_id_created_on",
                schema: "dbo",
                table: "agent_dividends",
                columns: new[] { "agent_id", "brand_id", "created_on" });

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividends_agent_id_sent_on",
                schema: "dbo",
                table: "agent_dividends",
                columns: new[] { "agent_id", "sent_on" });

            migrationBuilder.CreateIndex(
                name: "ix_agent_dividends_brand_id_from_to",
                schema: "dbo",
                table: "agent_dividends",
                columns: new[] { "brand_id", "from", "to" });

            migrationBuilder.CreateIndex(
                name: "ix_agent_login_records_agent_id",
                schema: "dbo",
                table: "agent_login_records",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_login_records_brand_id",
                schema: "dbo",
                table: "agent_login_records",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_transactions_agent_id",
                schema: "dbo",
                table: "agent_transactions",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_transactions_brand_id",
                schema: "dbo",
                table: "agent_transactions",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_transactions_wallet_id",
                schema: "dbo",
                table: "agent_transactions",
                column: "wallet_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_wallets_agent_id",
                schema: "dbo",
                table: "agent_wallets",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_agent_wallets_currency_code",
                schema: "dbo",
                table: "agent_wallets",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_agents_brand_id",
                schema: "dbo",
                table: "agents",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_agents_gist_path",
                schema: "dbo",
                table: "agents",
                column: "path")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "ix_agents_parent_agent_id",
                schema: "dbo",
                table: "agents",
                column: "parent_agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_aggregate_execution_time_multiple_keys",
                schema: "report",
                table: "aggregate_execution_time",
                columns: new[] { "aggregate_type", "from", "to" });

            migrationBuilder.CreateIndex(
                name: "ix_announcements_brand_id",
                schema: "dbo",
                table: "announcements",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_article_forms_brand_id",
                schema: "dbo",
                table: "article_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_banners_brand_id",
                schema: "dbo",
                table: "banners",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_bet_limits_currency_code",
                schema: "dbo",
                table: "bet_limits",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_brand_agent_dividend_conditions_brand_id",
                schema: "dbo",
                table: "brand_agent_dividend_conditions",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_bet_limits_bet_limit_id",
                schema: "dbo",
                table: "brand_bet_limits",
                column: "bet_limit_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_communications_brand_id",
                schema: "dbo",
                table: "brand_communications",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_contract_conditions_brand_contract_id",
                schema: "dbo",
                table: "brand_contract_conditions",
                column: "brand_contract_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_currencies_currency_code",
                schema: "dbo",
                table: "brand_currencies",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_brand_domains_brand_id",
                schema: "dbo",
                table: "brand_domains",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credit_profits_brand_id",
                schema: "dbo",
                table: "brand_game_credit_profits",
                columns: new[] { "brand_id", "month" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credit_txns_brand_id",
                schema: "dbo",
                table: "brand_game_credit_txns",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credit_txns_created_on_brand_id",
                schema: "dbo",
                table: "brand_game_credit_txns",
                columns: new[] { "created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credit_txns_created_on_brand_id_type",
                schema: "dbo",
                table: "brand_game_credit_txns",
                columns: new[] { "created_on", "brand_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credits_brand_id",
                schema: "dbo",
                table: "brand_game_credits",
                columns: new[] { "month", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credits_licensee_id",
                schema: "dbo",
                table: "brand_game_credits",
                columns: new[] { "month", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credits_month",
                schema: "dbo",
                table: "brand_game_credits",
                column: "month");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_credits_reseller_id",
                schema: "dbo",
                table: "brand_game_credits",
                columns: new[] { "month", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_provider_aggregate_audit_log_multiple_keys",
                schema: "dbo",
                table: "brand_game_provider_aggregate_audit_logs",
                columns: new[] { "created_on", "created_by_user_id", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_provider_aggregate_record_audit_log_id",
                schema: "report",
                table: "brand_game_provider_aggregate_records",
                column: "audit_log_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_provider_aggregate_audit_log_id",
                schema: "report",
                table: "brand_game_provider_aggregates",
                column: "audit_log_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_provider_aggregate_multiple_keys",
                schema: "report",
                table: "brand_game_provider_aggregates",
                columns: new[] { "report_date", "brand_id", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_provider_schedule_brand_game_provider_id",
                schema: "dbo",
                table: "brand_game_provider_schedules",
                column: "brand_game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_providers_default_language_code",
                schema: "dbo",
                table: "brand_game_providers",
                column: "default_language_code");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_providers_game_provider_configuration_id",
                schema: "dbo",
                table: "brand_game_providers",
                column: "game_provider_configuration_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_game_providers_game_provider_id",
                schema: "dbo",
                table: "brand_game_providers",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ux_brand_game_providers_brand_id_game_provider_id",
                schema: "dbo",
                table: "brand_game_providers",
                columns: new[] { "brand_id", "game_provider_id" },
                unique: true)
                .Annotation("Npgsql:IndexInclude", new[] { "game_provider_configuration_id", "status", "default_language_code", "desktop_query_string", "mobile_query_string" });

            migrationBuilder.CreateIndex(
                name: "ix_brand_games_game_id",
                schema: "dbo",
                table: "brand_games",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_group_bet_limits_bet_limit_id",
                schema: "dbo",
                table: "brand_group_bet_limits",
                column: "bet_limit_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_group_bet_limits_brand_group_id",
                schema: "dbo",
                table: "brand_group_bet_limits",
                column: "brand_group_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_group_game_provider_bet_limits_game_provider_bet_limit_id",
                schema: "dbo",
                table: "brand_group_game_provider_bet_limits",
                column: "game_provider_bet_limit_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_group_games_brand_game_id",
                schema: "dbo",
                table: "brand_group_games",
                column: "brand_game_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_groups_brand_id",
                schema: "dbo",
                table: "brand_groups",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_languages_culture_code",
                schema: "dbo",
                table: "brand_languages",
                column: "culture_code");

            migrationBuilder.CreateIndex(
                name: "ix_brand_maintenance_brand_id",
                schema: "dbo",
                table: "brand_maintenance",
                column: "brand_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_brand_payment_audit_logs_brand_payment_id",
                schema: "dbo",
                table: "brand_payment_audit_logs",
                column: "brand_payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_payment_players_player_code",
                schema: "dbo",
                table: "brand_payment_players",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_brand_payment_vip_levels_vip_level_id",
                schema: "dbo",
                table: "brand_payment_vip_levels",
                column: "vip_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_payments_brand_id",
                schema: "dbo",
                table: "brand_payments",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_brand_payments_payment_method_channel_id",
                schema: "dbo",
                table: "brand_payments",
                column: "payment_method_channel_id");

            migrationBuilder.CreateIndex(
                name: "ix_brands_licensee_id",
                schema: "dbo",
                table: "brands",
                column: "licensee_id");

            migrationBuilder.CreateIndex(
                name: "ix_departments_brand_id",
                schema: "dbo",
                table: "departments",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_departments_licensee_id",
                schema: "dbo",
                table: "departments",
                column: "licensee_id");

            migrationBuilder.CreateIndex(
                name: "ix_departments_reseller_id",
                schema: "dbo",
                table: "departments",
                column: "reseller_id");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_accumulate_roulette_events_brand_id",
                schema: "dbo",
                table: "deposit_accumulate_roulette_events",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_accumulate_roulette_events_promotion_id",
                schema: "dbo",
                table: "deposit_accumulate_roulette_events",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_accumulate_roulette_game_events_brand_id",
                schema: "dbo",
                table: "deposit_accumulate_roulette_game_events",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_accumulate_roulette_game_events_player_code",
                schema: "dbo",
                table: "deposit_accumulate_roulette_game_events",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_accumulate_roulette_game_events_promotion_id",
                schema: "dbo",
                table: "deposit_accumulate_roulette_game_events",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_forms_brand_payment_id",
                schema: "dbo",
                table: "deposit_forms",
                column: "brand_payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_forms_brandId",
                schema: "dbo",
                table: "deposit_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_deposit_forms_playerCode",
                schema: "dbo",
                table: "deposit_forms",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_distribute_register_events_brand_id",
                schema: "dbo",
                table: "distribute_register_events",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_distribute_register_events_player_code",
                schema: "dbo",
                table: "distribute_register_events",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_distribute_register_events_promotion_id",
                schema: "dbo",
                table: "distribute_register_events",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_draft_forms_brand_id",
                schema: "dbo",
                table: "draft_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_failed_game_record_operations_game_provider_id_auto_status_proces_status",
                schema: "bet",
                table: "failed_game_record_operations",
                columns: new[] { "game_provider_id", "auto_status", "proces_status" });

            migrationBuilder.CreateIndex(
                name: "ux_failed_game_record_operations_external_round_id_player_code_game_provider_id_game_id",
                schema: "bet",
                table: "failed_game_record_operations",
                columns: new[] { "external_round_id", "player_code", "game_provider_id", "game_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_function_event_sources_function_id",
                schema: "dbo",
                table: "function_event_sources",
                column: "function_id");

            migrationBuilder.CreateIndex(
                name: "ix_function_event_sources_system",
                schema: "dbo",
                table: "function_event_sources",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_functions_system",
                schema: "dbo",
                table: "functions",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_game_action_batches_game_provider_id",
                schema: "bet",
                table: "game_action_batches",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_actions_game_action_batch_id",
                schema: "bet",
                table: "game_actions",
                column: "game_action_batch_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_actions_player_code",
                schema: "bet",
                table: "game_actions",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_game_actions_referenced_game_action_id",
                schema: "bet",
                table: "game_actions",
                column: "referenced_game_action_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_actions_round_id",
                schema: "bet",
                table: "game_actions",
                column: "round_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_bets",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "game_provider_id", "game_id", "wallet_id", "external_bet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on",
                schema: "dbo",
                table: "game_bets",
                column: "external_created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_brand_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_closed_on",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "closed_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_closed_on_brand_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "closed_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_closed_on_player_code",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "closed_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_currency_code",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "currency_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_external_bet_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "external_bet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_external_round_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_g_p_c_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "game_provider_configuration_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_game_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_game_provider_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_licensee_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_player_code",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_reseller_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_bets_e_c_on_wallet_id",
                schema: "dbo",
                table: "game_bets",
                columns: new[] { "external_created_on", "wallet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_player_transform_idnlive_player_code",
                schema: "dbo",
                table: "game_player_transform_idnlive",
                column: "player_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_aggregate_audit_log_created_on",
                schema: "dbo",
                table: "game_provider_aggregate_audit_logs",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_aggregate_record_audit_log_id",
                schema: "report",
                table: "game_provider_aggregate_records",
                column: "audit_log_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_aggregate_audit_log_id",
                schema: "report",
                table: "game_provider_aggregates",
                column: "audit_log_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_aggregate_multiple_keys",
                schema: "report",
                table: "game_provider_aggregates",
                columns: new[] { "report_date", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_bet_limits_currency_code",
                schema: "dbo",
                table: "game_provider_bet_limits",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_bet_limits_game_provider_id",
                schema: "dbo",
                table: "game_provider_bet_limits",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_configurations_game_provider_id",
                schema: "dbo",
                table: "game_provider_configurations",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_currencies_currency_code",
                schema: "dbo",
                table: "game_provider_currencies",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_fund_transfer_transactions_player_code",
                schema: "dbo",
                table: "game_provider_fund_transfer_transactions",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_fund_transfer_transactions_transaction_id",
                schema: "dbo",
                table: "game_provider_fund_transfer_transactions",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_fund_transfer_transactions_wallet_id",
                schema: "dbo",
                table: "game_provider_fund_transfer_transactions",
                column: "wallet_id");

            migrationBuilder.CreateIndex(
                name: "ix_game_provider_languages_culture_code",
                schema: "dbo",
                table: "game_provider_languages",
                column: "culture_code");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_accum_on",
                schema: "dbo",
                table: "game_wager_player_accums",
                column: "accum_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_brand_id",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_licensee_id",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_player_code",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_player_accums_reseller_id",
                schema: "dbo",
                table: "game_wager_player_accums",
                columns: new[] { "accum_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_closes_brand_id",
                schema: "dbo",
                table: "game_wager_stat_closes",
                columns: new[] { "stat_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_closes_game_id",
                schema: "dbo",
                table: "game_wager_stat_closes",
                columns: new[] { "stat_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_closes_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_closes",
                columns: new[] { "stat_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_closes_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_closes",
                columns: new[] { "stat_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_closes_player_code",
                schema: "dbo",
                table: "game_wager_stat_closes",
                columns: new[] { "stat_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_closes_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_closes",
                columns: new[] { "stat_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_closes_stat_on",
                schema: "dbo",
                table: "game_wager_stat_closes",
                column: "stat_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_brand_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "stat_day_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_d_game_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "stat_day_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_d_player_code",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "stat_day_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "stat_day_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "stat_day_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_game_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_player_code",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                columns: new[] { "stat_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_c_stat_on",
                schema: "dbo",
                table: "game_wager_stat_daily_closes",
                column: "stat_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_brand_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_d_game_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_d_player_code",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "stat_day_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_game_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_player_code",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                columns: new[] { "stat_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_d_z_c_stat_on",
                schema: "dbo",
                table: "game_wager_stat_daily_zone_closes",
                column: "stat_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_brand_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_game_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_h_brand_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_h_game_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_h_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_h_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_h_player_code",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_h_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_h_stat_hour_on",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_player_code",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "stat_day_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_game_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_player_code",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                columns: new[] { "stat_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_c_stat_on",
                schema: "dbo",
                table: "game_wager_stat_hourly_closes",
                column: "stat_on");

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_brand_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_brand_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_game_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_h_brand_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "brand_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_h_game_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_h_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_h_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_h_player_code",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_h_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_h_stat_hour_on",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "stat_hour_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_player_code",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_d_stat_day_on",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "stat_day_on" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_game_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "game_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_game_provider_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "game_provider_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_licensee_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "licensee_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_player_code",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_reseller_id",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                columns: new[] { "stat_on", "reseller_id" });

            migrationBuilder.CreateIndex(
                name: "ix_game_wager_stat_h_z_c_stat_on",
                schema: "dbo",
                table: "game_wager_stat_hourly_zone_closes",
                column: "stat_on");

            migrationBuilder.CreateIndex(
                name: "ix_games_game_provider_id",
                schema: "dbo",
                table: "games",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_games_sub_game_provider_code",
                schema: "dbo",
                table: "games",
                column: "sub_game_provider_code");

            migrationBuilder.CreateIndex(
                name: "ix_group_users_system",
                schema: "dbo",
                table: "group_users",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_groups_system",
                schema: "dbo",
                table: "groups",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_licensee_bet_limits_bet_limit_id",
                schema: "dbo",
                table: "licensee_bet_limits",
                column: "bet_limit_id");

            migrationBuilder.CreateIndex(
                name: "ix_licensee_currencies_currency_code",
                schema: "dbo",
                table: "licensee_currencies",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_licensee_game_providers_game_provider_id",
                schema: "dbo",
                table: "licensee_game_providers",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_licensee_languages_culture_code",
                schema: "dbo",
                table: "licensee_languages",
                column: "culture_code");

            migrationBuilder.CreateIndex(
                name: "ix_licensees_reseller_id",
                schema: "dbo",
                table: "licensees",
                column: "reseller_id");

            migrationBuilder.CreateIndex(
                name: "ix_localized_strings_culture_code",
                schema: "dbo",
                table: "localized_strings",
                column: "culture_code");

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_brand_id",
                schema: "dbo",
                table: "notification_contacts",
                columns: new[] { "brand_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_licensee_id",
                schema: "dbo",
                table: "notification_contacts",
                columns: new[] { "licensee_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_reseller_id",
                schema: "dbo",
                table: "notification_contacts",
                columns: new[] { "reseller_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_notification_contacts_typ",
                schema: "dbo",
                table: "notification_contacts",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "ix_offline_login_reward_events_brand_id",
                schema: "dbo",
                table: "offline_login_reward_events",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_offline_login_reward_events_player_code",
                schema: "dbo",
                table: "offline_login_reward_events",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_offline_login_reward_events_promotion_id",
                schema: "dbo",
                table: "offline_login_reward_events",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_handling_fees_brand_id",
                schema: "dbo",
                table: "payment_handling_fees",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_handling_fees_form_id",
                schema: "dbo",
                table: "payment_handling_fees",
                column: "form_id")
                .Annotation("Npgsql:IndexInclude", new[] { "amount", "fee", "recorded_on" });

            migrationBuilder.CreateIndex(
                name: "ix_payment_handling_fees_recorded_on_form_id",
                schema: "dbo",
                table: "payment_handling_fees",
                columns: new[] { "recorded_on", "form_id" })
                .Annotation("Npgsql:IndexInclude", new[] { "amount", "fee" });

            migrationBuilder.CreateIndex(
                name: "ix_payment_method_channels_channel_id",
                schema: "dbo",
                table: "payment_method_channels",
                column: "channel_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_method_channels_method_id",
                schema: "dbo",
                table: "payment_method_channels",
                column: "method_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_method_channels_payment_id",
                schema: "dbo",
                table: "payment_method_channels",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_fk_functions",
                schema: "dbo",
                table: "permissions",
                column: "fk_functions");

            migrationBuilder.CreateIndex(
                name: "ix_permissions_system",
                schema: "dbo",
                table: "permissions",
                column: "system");

            migrationBuilder.CreateIndex(
                name: "ix_platform_credits_brand_id",
                schema: "dbo",
                table: "platform_credits",
                column: "brand_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_brand_credits_id",
                schema: "dbo",
                table: "platform_pay_records",
                column: "platform_credit_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_agent_relations_agent_id",
                schema: "dbo",
                table: "player_agent_relations",
                column: "agent_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_agent_relations_brand_id",
                schema: "dbo",
                table: "player_agent_relations",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_aggregates_agent_id",
                schema: "report",
                table: "player_aggregates",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_aggregates_multiple_keys",
                schema: "report",
                table: "player_aggregates",
                columns: new[] { "report_date", "brand_id", "agent_id", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebate_contributors_settle_date_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_contributors",
                columns: new[] { "settle_date", "player_code", "child_player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebate_records_settle_date_brand_id_player_code",
                schema: "dbo",
                table: "player_all_agent_rebate_records",
                columns: new[] { "settle_date", "brand_id", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_all_agent_rebates_brand_id_report_date_player_code",
                schema: "dbo",
                table: "player_all_agent_rebates",
                columns: new[] { "brand_id", "report_date", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_bank_info_tags_bank_info_id",
                schema: "dbo",
                table: "player_bank_info_tags",
                column: "bank_info_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_bank_info_tags_player_code",
                schema: "dbo",
                table: "player_bank_info_tags",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_bank_infos_brand_id",
                schema: "dbo",
                table: "player_bank_infos",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_bank_infos_payment_channel_id",
                schema: "dbo",
                table: "player_bank_infos",
                column: "payment_channel_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_bank_infos_player_code",
                schema: "dbo",
                table: "player_bank_infos",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_bankinfo_attributions_player_code",
                schema: "dbo",
                table: "player_bankinfo_attributions",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_bonus_aggregates_multiple_keys",
                schema: "report",
                table: "player_bonus_aggregates",
                columns: new[] { "report_date", "brand_id", "agent_id", "player_code" },
                descending: new[] { true, false, false, false });

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms_brand_id",
                schema: "dbo",
                table: "player_bucket_clean_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms_player_code",
                schema: "dbo",
                table: "player_bucket_clean_forms",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms2_brand_id",
                schema: "dbo",
                table: "player_bucket_clean_forms2",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_clean_forms2_player_code",
                schema: "dbo",
                table: "player_bucket_clean_forms2",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_bucket_histories_player_code",
                schema: "dbo",
                table: "player_bucket_histories",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_buckets_player_code",
                schema: "dbo",
                table: "player_buckets",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_favorite_games_brand_id",
                schema: "dbo",
                table: "player_favorite_games",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_game_rebate_aggregates_multiple_keys",
                schema: "report",
                table: "player_game_rebate_aggregates",
                columns: new[] { "report_date", "brand_id", "agent_id", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_login_records_brand_id",
                schema: "dbo",
                table: "player_login_records",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_login_records_player_code",
                schema: "dbo",
                table: "player_login_records",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_properties_player_code",
                schema: "dbo",
                table: "player_properties",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_player_rebates_brand_id_report_date",
                schema: "dbo",
                table: "player_rebates",
                columns: new[] { "brand_id", "report_date" });

            migrationBuilder.CreateIndex(
                name: "ix_player_rebates_brand_id_report_date_agent_id",
                schema: "dbo",
                table: "player_rebates",
                columns: new[] { "brand_id", "report_date", "agent_id" });

            migrationBuilder.CreateIndex(
                name: "ix_player_rebates_brand_id_report_date_player_code",
                schema: "dbo",
                table: "player_rebates",
                columns: new[] { "brand_id", "report_date", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_sports_bet_limits_sport_market_id",
                schema: "dbo",
                table: "player_sports_bet_limits",
                column: "sport_market_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_b_f_created_on",
                schema: "dbo",
                table: "player_vip_level_birthday_forms",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "uni_player_vip_level_b_f_player_code_birthday",
                schema: "dbo",
                table: "player_vip_level_birthday_forms",
                columns: new[] { "player_code", "birthday" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_cycle_f_created_on",
                schema: "dbo",
                table: "player_vip_level_cycle_forms",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "uni_player_vip_level_cycle_f_player_code_cycle",
                schema: "dbo",
                table: "player_vip_level_cycle_forms",
                columns: new[] { "player_code", "cycle_type", "cycle_on" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_logs_created_on",
                schema: "dbo",
                table: "player_vip_level_logs",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_logs_created_on_player_code",
                schema: "dbo",
                table: "player_vip_level_logs",
                columns: new[] { "created_on", "player_code" });

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_u_f_created_on",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms",
                column: "created_on");

            migrationBuilder.CreateIndex(
                name: "ix_player_vip_level_u_f_player_code_vip_level",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms",
                columns: new[] { "player_code", "vip_level" });

            migrationBuilder.CreateIndex(
                name: "uni_player_vip_level_u_f_player_code_vip_level",
                schema: "dbo",
                table: "player_vip_level_upgrade_forms",
                columns: new[] { "player_code", "vip_level", "repeat_times" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_players_agent_id",
                schema: "dbo",
                table: "players",
                column: "agent_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_bet_limit_id",
                schema: "dbo",
                table: "players",
                column: "bet_limit_id");

            migrationBuilder.CreateIndex(
                name: "ix_players_vip_id",
                schema: "dbo",
                table: "players",
                column: "vip_id");

            migrationBuilder.CreateIndex(
                name: "ux_players_brand_phone",
                schema: "dbo",
                table: "players",
                columns: new[] { "brand_id", "area_code", "phone" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_promotion_bonus_brand_id",
                schema: "dbo",
                table: "promotion_bonuses",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_bonus_brand_id_from_to",
                schema: "dbo",
                table: "promotion_bonuses",
                columns: new[] { "brand_id", "from", "to" });

            migrationBuilder.CreateIndex(
                name: "ix_promotion_bonus_promotion_id",
                schema: "dbo",
                table: "promotion_bonuses",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_bonus_promotion_id_from_to",
                schema: "dbo",
                table: "promotion_bonuses",
                columns: new[] { "promotion_id", "from", "to" });

            migrationBuilder.CreateIndex(
                name: "ux_promotion_distrubute_plans",
                schema: "dbo",
                table: "promotion_distribute_plans",
                columns: new[] { "brand_id", "promotion_id", "condition_hash" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ux_promotion_distributes",
                schema: "dbo",
                table: "promotion_distributes",
                columns: new[] { "player_code", "plan_id" },
                unique: true,
                filter: "plan_id IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_game_provider_game_provider_id",
                schema: "dbo",
                table: "promotion_game_providers",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_participant_player_code",
                schema: "dbo",
                table: "promotion_participants",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_participants_promotion_id",
                schema: "dbo",
                table: "promotion_participants",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_player_multiple_keys",
                schema: "dbo",
                table: "promotion_players",
                columns: new[] { "player_code", "promotion_bonus_id" });

            migrationBuilder.CreateIndex(
                name: "ix_promotion_player_promotion_id",
                schema: "dbo",
                table: "promotion_players",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_players_promotion_bonus_id",
                schema: "dbo",
                table: "promotion_players",
                column: "promotion_bonus_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_vip_level_vip_level_id",
                schema: "dbo",
                table: "promotion_vip_levels",
                column: "level");

            migrationBuilder.CreateIndex(
                name: "ix_promotion_vip_levels_vip_level_id",
                schema: "dbo",
                table: "promotion_vip_levels",
                column: "vip_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotions_brand_id",
                schema: "dbo",
                table: "promotions",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_promotions_vip_level_id",
                schema: "dbo",
                table: "promotions",
                column: "vip_level_id");

            migrationBuilder.CreateIndex(
                name: "ix_rebate_promotion_join_players_player_code",
                schema: "dbo",
                table: "rebate_promotion_join_players",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_relief_promotion_join_players_player_code",
                schema: "dbo",
                table: "relief_promotion_join_players",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_reseller_bet_limits_bet_limit_id",
                schema: "dbo",
                table: "reseller_bet_limits",
                column: "bet_limit_id");

            migrationBuilder.CreateIndex(
                name: "ix_reseller_currencies_currency_code",
                schema: "dbo",
                table: "reseller_currencies",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_reseller_game_providers_game_provider_id",
                schema: "dbo",
                table: "reseller_game_providers",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_reseller_languages_culture_code",
                schema: "dbo",
                table: "reseller_languages",
                column: "culture_code");

            migrationBuilder.CreateIndex(
                name: "ix_roulette_sign_in_events_brand_id",
                schema: "dbo",
                table: "roulette_sign_in_events",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_roulette_sign_in_events_player_code",
                schema: "dbo",
                table: "roulette_sign_in_events",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_roulette_sign_in_events_promotion_id",
                schema: "dbo",
                table: "roulette_sign_in_events",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_round_aggregate_multiple_keys",
                schema: "report",
                table: "round_aggregates",
                columns: new[] { "report_date", "hour", "minute" });

            migrationBuilder.CreateIndex(
                name: "ix_round_aggregate_player_code",
                schema: "report",
                table: "round_aggregates",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_round_operation_records_round_id",
                schema: "bet",
                table: "round_operation_records",
                column: "round_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_brand_id",
                schema: "bet",
                table: "rounds",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_closed_on",
                schema: "bet",
                table: "rounds",
                column: "closed_on")
                .Annotation("Npgsql:IndexMethod", "brin");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_game_id",
                schema: "bet",
                table: "rounds",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_game_provider_configuration_id_composite",
                schema: "bet",
                table: "rounds",
                columns: new[] { "game_provider_configuration_id", "wallet_id", "game_id", "external_round_id" });

            migrationBuilder.CreateIndex(
                name: "ix_rounds_game_provider_id",
                schema: "bet",
                table: "rounds",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_player_code",
                schema: "bet",
                table: "rounds",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_rounds_wallet_id_composite",
                schema: "bet",
                table: "rounds",
                columns: new[] { "external_round_id", "game_provider_id", "game_id", "wallet_id" });

            migrationBuilder.CreateIndex(
                name: "ix_sign_in_events_brand_id",
                schema: "dbo",
                table: "sign_in_events",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_sign_in_events_player_code",
                schema: "dbo",
                table: "sign_in_events",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_sign_in_events_promotion_id",
                schema: "dbo",
                table: "sign_in_events",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_sport_market_types_market_type_id",
                schema: "dbo",
                table: "sport_market_types",
                column: "market_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_sport_types_game_provider_id",
                schema: "dbo",
                table: "sport_types",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_station_letter_players_player_code",
                schema: "dbo",
                table: "station_letter_players",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_station_letters_brand_id",
                schema: "dbo",
                table: "station_letters",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_sub_game_providers_game_provider_id",
                schema: "dbo",
                table: "sub_game_providers",
                column: "game_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_transaction_Promotion_id",
                schema: "dbo",
                table: "transaction_promotions",
                column: "promotion_id");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_transaction_id",
                schema: "dbo",
                table: "transaction_promotions",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_brand_id",
                schema: "dbo",
                table: "transactions",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_player_code",
                schema: "dbo",
                table: "transactions",
                column: "player_code");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_wallet_id",
                schema: "dbo",
                table: "transactions",
                column: "wallet_id");

            migrationBuilder.CreateIndex(
                name: "ix_transfer_balance_forms_brand_id",
                schema: "dbo",
                table: "transfer_balance_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_department_id",
                schema: "dbo",
                table: "users",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_role_id",
                schema: "dbo",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_vip_level_snapshots_brand_id",
                schema: "dbo",
                table: "vip_level_snapshots",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_vip_levels_brand_id",
                schema: "dbo",
                table: "vip_levels",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_wallets_currency_code",
                schema: "dbo",
                table: "wallets",
                column: "currency_code");

            migrationBuilder.CreateIndex(
                name: "ix_whitelists_brand_id",
                schema: "dbo",
                table: "whitelists",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_whitelists_licensee_id",
                schema: "dbo",
                table: "whitelists",
                column: "licensee_id");

            migrationBuilder.CreateIndex(
                name: "ix_whitelists_reseller_id",
                schema: "dbo",
                table: "whitelists",
                column: "reseller_id");

            migrationBuilder.CreateIndex(
                name: "ix_withdraw_forms_brand_id",
                schema: "dbo",
                table: "withdraw_forms",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_withdraw_froms_brand_payment_id",
                schema: "dbo",
                table: "withdraw_forms",
                column: "brand_payment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_event_sources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "accounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjust_agent_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjust_player_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adjust_transfer_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "admin_logs",
                schema: "log");

            migrationBuilder.DropTable(
                name: "agent_audit_logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_bank_infos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_banks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_clear_commission_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_daily_marketing_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_daily_payment_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_conditions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_contracts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_multiple_layers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_product_fees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividend_snapshots",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_domains",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_login_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_product_fees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_transactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "aggregate_execution_time",
                schema: "report");

            migrationBuilder.DropTable(
                name: "announcements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "api_logs",
                schema: "log");

            migrationBuilder.DropTable(
                name: "article_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "background_payment_statistics_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "banners",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_agent_dividend_conditions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_all_agent_game_type_conditions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_all_agent_game_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_all_agent_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_all_agents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_bucket_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_communications",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_contract_conditions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_currencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_daily_marketing_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_daily_payment_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_domains",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_game_credit_profits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_game_credit_susp_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_game_credit_txns",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_game_credits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_game_provider_aggregate_audit_logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_game_provider_aggregate_records",
                schema: "report");

            migrationBuilder.DropTable(
                name: "brand_game_provider_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "brand_game_provider_schedules",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_group_game_provider_bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_group_games",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_live_chats",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_maintenance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_audit_logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_auto_withdraw",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_auto_withdraw_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payment_vip_levels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_player_bankinfo_check_flags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_player_contract_display",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_product_fees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_sms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "calculate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "calculate_change_log",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deposit_accumulate_roulette_events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deposit_accumulate_roulette_game_events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deposit_form_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deposit_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deposit_promotion_calculate_pairs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deposit_promotion_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "distribute_register_events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "draft_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "failed_game_record_operations",
                schema: "bet");

            migrationBuilder.DropTable(
                name: "five_minutes_payment_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "five_minutes_payment_statistics_delta",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "function_event_sources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_actions",
                schema: "bet");

            migrationBuilder.DropTable(
                name: "game_bets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_betting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_player_transform_idnlive",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_provider_aggregate_audit_logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_provider_aggregate_records",
                schema: "report");

            migrationBuilder.DropTable(
                name: "game_provider_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "game_provider_currencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_provider_fund_transfer_transactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_provider_languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_type_round_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "game_wager_player_accums",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_stat_closes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_stat_daily_closes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_stat_daily_zone_closes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_stat_hourly_closes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_wager_stat_hourly_zone_closes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "group_users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "hour_payment_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "licensee_bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "licensee_currencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "licensee_game_providers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "licensee_languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "localized_strings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "log_records",
                schema: "log");

            migrationBuilder.DropTable(
                name: "marketing_report_daily_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "marketing_statistics_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "notification_contacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "offline_deposit_events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "offline_login_reward_events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "payment_handling_fees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "platform_pay_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_agent_relations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "player_all_agent_rebate_contributors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_all_agent_rebate_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_all_agent_rebates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_audit_logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_authentication_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bank_info_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bank_info_tags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bankinfo_attributions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bonus_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "player_bucket_clean_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bucket_clean_event_source2",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bucket_clean_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bucket_clean_forms2",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bucket_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bucket_histories",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bucket_migrations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_buckets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_daily_gaming_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_daily_payment_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_daily_register_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_favorite_games",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_game_rebate_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "player_game_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_identity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_ip_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_login_records",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_parents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_payment_overview",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_properties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_rebates",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_sports_bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_tags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_birthday_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_cycle_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_level_upgrade_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_vip_levels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_distribute_logs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_distribute_plans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_distributes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_game_providers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_participants",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_promote_deposit_channels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_rebate_daily_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_rebate_distributes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_relief_daily_statistics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_relief_distributes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_vip_levels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "rebate_promotion_join_players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "relief_promotion_join_players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "reseller_bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "reseller_currencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "reseller_game_providers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "reseller_languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "roulette_sign_in_events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "round_aggregates",
                schema: "report");

            migrationBuilder.DropTable(
                name: "round_details",
                schema: "bet");

            migrationBuilder.DropTable(
                name: "round_operation_records",
                schema: "bet");

            migrationBuilder.DropTable(
                name: "settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sign_in_events",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sms_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "social_media_settings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "station_letter_delivery_box",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "station_letter_players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "station_letter2",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "system_localizations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "transaction_promotions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "transactions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "transfer_balance_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "vip_level_snapshots",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "whitelists",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "withdraw_form_event_source",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "withdraw_forms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_dividends",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agent_wallets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_contracts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_game_providers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_group_bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_provider_bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_games",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_action_batches",
                schema: "bet");

            migrationBuilder.DropTable(
                name: "groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "functions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "platform_credits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "player_bank_infos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sport_market_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotion_bonuses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "rounds",
                schema: "bet");

            migrationBuilder.DropTable(
                name: "station_letters",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "wallets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_payments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_provider_configurations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "languages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brand_groups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "games",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "systems",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "players",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "market_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sport_types",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "promotions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "payment_method_channels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "sub_game_providers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "agents",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "bet_limits",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "vip_levels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "payment_channels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "payment_methods",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "payments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "game_providers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "licensees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "resellers",
                schema: "dbo");
        }
    }
}
