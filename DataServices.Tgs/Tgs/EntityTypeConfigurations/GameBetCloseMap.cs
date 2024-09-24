using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameBetCloseMap : IEntityTypeConfiguration<GameBetClose>
{
    void IEntityTypeConfiguration<GameBetClose>.Configure(EntityTypeBuilder<GameBetClose> builder)
    {
        _ = builder.ToTable("game_bet_closes", "dbo");

        _ = builder.HasKey(e => new { e.ClosedOn, e.GameBetMajorId }).HasName("pk_game_bet_closes");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.BrandId }, "ix_game_bet_closes_brand_id");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.ExternalClosedOn }, "ix_game_bet_closes_external_closed_on");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.ExternalCreatedOn }, "ix_game_bet_closes_external_created_on");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.GameId }, "ix_game_bet_closes_game_id");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.GameProviderId }, "ix_game_bet_closes_game_provider_id");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.Id }, "ix_game_bet_closes_id");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.PlayerCode }, "ix_game_bet_closes_player_code");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.UpdatedOn }, "ix_game_bet_closes_updated_on");

        _ = builder.HasIndex(e => new { e.ClosedOn, e.GameProviderId, e.GameId, e.WalletId, e.ExternalBetId }, "uix_game_bet_closes").IsUnique();

        _ = builder.Property(e => e.ClosedOn)
            .HasComment("結束時間")
            .HasColumnName("closed_on");
        _ = builder.Property(e => e.GameBetMajorId)
            .HasComment("遊戲投注主要識別碼")
            .HasColumnName("game_bet_major_id")
            .IsRequired();
        _ = builder.Property(e => e.AdditionalData)
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("附加數據")
            .HasColumnType("jsonb")
            .HasColumnName("additional_data")
            .IsRequired();
        _ = builder.Property(e => e.Bet)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("下注")
            .HasColumnName("bet")
            .IsRequired();
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
        _ = builder.Property(e => e.Commission)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("傭金")
            .HasColumnName("commission")
            .IsRequired();
        _ = builder.Property(e => e.Contribute)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("貢獻/彩金貢獻")
            .HasColumnName("contribute")
            .IsRequired();
        _ = builder.Property(e => e.CreatedOn)
            .HasComment("創建時間")
            .HasColumnName("created_on");
        _ = builder.Property(e => e.CurrencyCode)
            .HasMaxLength(16)
            .HasDefaultValueSql("''::character varying")
            .HasComment("貨幣代碼")
            .HasColumnName("currency_code")
            .IsRequired();
        _ = builder.Property(e => e.CurrencyRatio)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("貨幣比例")
            .HasColumnName("currency_ratio")
            .IsRequired();
        _ = builder.Property(e => e.ExtendedData)
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("擴充數據")
            .HasColumnType("jsonb")
            .HasColumnName("extended_data")
            .IsRequired();
        _ = builder.Property(e => e.ExternalBetId)
            .HasMaxLength(255)
            .HasDefaultValueSql("''::character varying")
            .HasComment("三方投注單別碼")
            .HasColumnName("external_bet_id")
            .IsRequired();
        _ = builder.Property(e => e.ExternalClosedOn)
            .HasComment("三方結算/結束時間")
            .HasColumnName("external_closed_on");
        _ = builder.Property(e => e.ExternalCreatedOn)
            .HasComment("三方下注/創建時間")
            .HasColumnName("external_created_on");
        _ = builder.Property(e => e.ExternalPayoffOn)
            .HasComment("三方派彩時間")
            .HasColumnName("external_payoff_on");
        _ = builder.Property(e => e.ExternalResettleOn)
            .HasComment("三方重新結算時間")
            .HasColumnName("external_resettle_on");
        _ = builder.Property(e => e.ExternalRoundId)
            .HasMaxLength(255)
            .HasDefaultValueSql("''::character varying")
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
        _ = builder.Property(e => e.GameId)
            .HasComment("遊戲識別碼")
            .HasColumnName("game_id");
        _ = builder.Property(e => e.GameProviderConfigurationId)
            .HasComment("遊戲供應商設定識別碼")
            .HasColumnName("game_provider_configuration_id");
        _ = builder.Property(e => e.GameProviderId)
            .HasComment("遊戲供應商識別碼")
            .HasColumnName("game_provider_id");
        _ = builder.Property(e => e.Id)
            .HasComment("識別碼")
            .HasColumnName("id");
        _ = builder.Property(e => e.Jackpot)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("彩金")
            .HasColumnName("jackpot")
            .IsRequired();
        _ = builder.Property(e => e.JackpotState)
            .HasDefaultValue(0)
            .HasComment("彩金狀態")
            .HasColumnName("jackpot_state");
        _ = builder.Property(e => e.LicenseeId)
            .HasComment("分公司識別碼")
            .HasColumnName("licensee_id");
        _ = builder.Property(e => e.PlayerCode)
            .HasMaxLength(16)
            .HasDefaultValueSql("''::character varying")
            .HasComment("玩家代碼")
            .HasColumnName("player_code")
            .IsRequired();
        _ = builder.Property(e => e.ResellerId)
            .HasComment("公司識別碼")
            .HasColumnName("reseller_id");
        _ = builder.Property(e => e.ResetOn)
            .HasComment("重置時間")
            .HasColumnName("reset_on");
        _ = builder.Property(e => e.ResetState)
            .HasDefaultValue(0)
            .HasComment("重置狀態")
            .HasColumnName("reset_state");
        _ = builder.Property(e => e.ResettleState)
            .HasDefaultValue(0)
            .HasComment("重新結算狀態")
            .HasColumnName("resettle_state");
        _ = builder.Property(e => e.Settle)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("結算(包含本金)")
            .HasColumnName("settle")
            .IsRequired();
        _ = builder.Property(e => e.Turnover)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("流水(依照遊戲商提供流水,如遊戲商未提供預設有效下注)")
            .HasColumnName("turnover")
            .IsRequired();
        _ = builder.Property(e => e.UpdatedOn)
            .HasComment("修改時間")
            .HasColumnName("updated_on");
        _ = builder.Property(e => e.ValidBet)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("實際/有效下注")
            .HasColumnName("valid_bet")
            .IsRequired();
        _ = builder.Property(e => e.WalletId)
            .HasComment("錢包識別碼")
            .HasColumnName("wallet_id");
        _ = builder.Property(e => e.WinLoss)
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("玩家損益/淨利")
            .HasColumnName("win_loss")
            .IsRequired();
    }
}
