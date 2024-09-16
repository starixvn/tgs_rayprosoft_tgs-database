using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TGS.Core.DataServices.Tgs.Models;
using static Dapper.SqlMapper;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameBetMajorMap : IEntityTypeConfiguration<GameBetMajor>
{
    void IEntityTypeConfiguration<GameBetMajor>.Configure(EntityTypeBuilder<GameBetMajor> builder)
    {
        _ = builder.ToTable("game_bet_majors");

        _ = builder.HasKey(e => new { e.ExternalCreatedOn, e.GameProviderId, e.GameId, e.WalletId, e.ExternalBetId }).HasName("pk_game_bet_majors");

        _ = builder.HasIndex(e => e.ExternalCreatedOn, "ix_game_bet_majors_e_crt");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.BrandId }, "ix_game_bet_majors_e_crt_brand_id");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.ClosedOn }, "ix_game_bet_majors_e_crt_closed_on");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.CreatedOn }, "ix_game_bet_majors_e_crt_created_on");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.CurrencyCode }, "ix_game_bet_majors_e_crt_currency_code");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.ExternalBetId }, "ix_game_bet_majors_e_crt_external_bet_id");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.ExternalClosedOn }, "ix_game_bet_majors_e_crt_external_closed_on");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.ExternalPayoffOn }, "ix_game_bet_majors_e_crt_external_payoff_on");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.ExternalResettleOn }, "ix_game_bet_majors_e_crt_external_resettle_on");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.ExternalRoundId }, "ix_game_bet_majors_e_crt_external_round_id");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.GameId }, "ix_game_bet_majors_e_crt_game_id");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.GameProviderId }, "ix_game_bet_majors_e_crt_game_provider_id");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.Id }, "ix_game_bet_majors_e_crt_id");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.PlayerCode }, "ix_game_bet_majors_e_crt_player_code");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.UpdatedOn }, "ix_game_bet_majors_e_crt_updated_on");

        _ = builder.HasIndex(e => new { e.ExternalCreatedOn, e.WalletId }, "ix_game_bet_majors_e_crt_wallet_id");

        _ = builder.Property(e => e.ExternalCreatedOn)
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方下注/創建時間")
            .HasColumnName("external_created_on");
        _ = builder.Property(e => e.GameProviderId)
            .HasComment("遊戲供應商識別碼")
            .HasColumnName("game_provider_id");
        _ = builder.Property(e => e.GameId)
            .HasComment("遊戲識別碼")
            .HasColumnName("game_id");
        _ = builder.Property(e => e.WalletId)
            .HasComment("錢包識別碼")
            .HasColumnName("wallet_id");
        _ = builder.Property(e => e.ExternalBetId)
            .HasMaxLength(255)
            .HasComment("三方投注單別碼")
            .HasColumnName("external_bet_id");
        _ = builder.Property(e => e.AdditionalData)
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("附加數據")
            .HasColumnType("jsonb")
            .HasColumnName("additional_data")
            .IsRequired();
        _ = builder.Property(e => e.Bet)
            .HasPrecision(18, 6)
            .HasComment("下注")
            .HasColumnName("bet");
        _ = builder.Property(e => e.BetState)
            .HasDefaultValue(0)
            .HasComment("注單狀態")
            .HasColumnName("bet_state");
        _ = builder.Property(e => e.BetType)
            .HasDefaultValue(0)
            .HasComment("注單類型")
            .HasColumnName("bet_type");
        _ = builder.Property(e => e.BrandId)
            .HasComment("平台識別碼")
            .HasColumnName("brand_id");
        _ = builder.Property(e => e.CashoutState)
            .HasDefaultValue(0)
            .HasComment("兌現狀態")
            .HasColumnName("cashout_state");
        _ = builder.Property(e => e.ClosedOn)
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("結束時間")
            .HasColumnName("closed_on");
        _ = builder.Property(e => e.Commission)
            .HasPrecision(18, 6)
            .HasComment("傭金")
            .HasColumnName("commission");
        _ = builder.Property(e => e.Contribute)
            .HasPrecision(18, 6)
            .HasComment("貢獻/彩金貢獻")
            .HasColumnName("contribute");
        _ = builder.Property(e => e.CreatedOn)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間")
            .HasColumnName("created_on");
        _ = builder.Property(e => e.CurrencyCode)
            .HasMaxLength(16)
            .HasComment("貨幣代碼")
            .HasColumnName("currency_code")
            .IsRequired();
        _ = builder.Property(e => e.CurrencyRatio)
            .HasPrecision(18, 6)
            .HasComment("貨幣比例")
            .HasColumnName("currency_ratio");
        _ = builder.Property(e => e.ExtendedData)
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("擴充數據")
            .HasColumnType("jsonb")
            .HasColumnName("extended_data")
            .IsRequired();
        _ = builder.Property(e => e.ExternalClosedOn)
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方結算/結束時間")
            .HasColumnName("external_closed_on");
        _ = builder.Property(e => e.ExternalPayoffOn)
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方派彩時間")
            .HasColumnName("external_payoff_on");
        _ = builder.Property(e => e.ExternalResettleOn)
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方重新結算時間")
            .HasColumnName("external_resettle_on");
        _ = builder.Property(e => e.ExternalRoundId)
            .HasMaxLength(255)
            .HasComment("三方局/回合識別碼")
            .HasColumnName("external_round_id")
            .IsRequired();
        _ = builder.Property(e => e.FreeGameState)
            .HasDefaultValue(0)
            .HasComment("免費遊戲狀態")
            .HasColumnName("free_game_state");
        _ = builder.Property(e => e.GambleState)
            .HasDefaultValue(0)
            .HasComment("博取遊戲狀態")
            .HasColumnName("gamble_state");
        _ = builder.Property(e => e.GameProviderConfigurationId)
            .HasComment("遊戲供應商設定識別碼")
            .HasColumnName("game_provider_configuration_id");
        _ = builder.Property(e => e.Id)
            .HasComment("識別碼")
            .HasColumnName("id");
        _ = builder.Property(e => e.Jackpot)
            .HasPrecision(18, 6)
            .HasComment("彩金")
            .HasColumnName("jackpot");
        _ = builder.Property(e => e.JackpotState)
            .HasDefaultValue(0)
            .HasComment("彩金狀態")
            .HasColumnName("jackpot_state");
        _ = builder.Property(e => e.LicenseeId)
            .HasComment("分公司識別碼")
            .HasColumnName("licensee_id");
        _ = builder.Property(e => e.PlayerCode)
            .HasMaxLength(16)
            .HasComment("玩家代碼")
            .HasColumnName("player_code")
            .IsRequired();
        _ = builder.Property(e => e.ResellerId)
            .HasComment("公司識別碼")
            .HasColumnName("reseller_id");
        _ = builder.Property(e => e.ResettleState)
            .HasDefaultValue(0)
            .HasComment("重新結算狀態")
            .HasColumnName("resettle_state");
        _ = builder.Property(e => e.Settle)
            .HasPrecision(18, 6)
            .HasComment("結算(包含本金)")
            .HasColumnName("settle");
        _ = builder.Property(e => e.UpdatedOn)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("修改時間")
            .HasColumnName("updated_on");
        _ = builder.Property(e => e.ValidBet)
            .HasPrecision(18, 6)
            .HasComment("實際/有效下注")
            .HasColumnName("valid_bet");
        _ = builder.Property(e => e.WinLoss)
            .HasPrecision(18, 6)
            .HasComment("玩家損益/淨利")
            .HasColumnName("win_loss");
    }
}
