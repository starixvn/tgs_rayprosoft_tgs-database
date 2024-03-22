using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.DataServices.Base;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameBetEventSourceMap : IEntityTypeConfiguration<GameBetEventSource>
{
    void IEntityTypeConfiguration<GameBetEventSource>.Configure(EntityTypeBuilder<GameBetEventSource> builder)
    {
        _ = builder.ToTable("game_bet_event_sources");

        _ = builder
            .HasKey(c => new { c.CreatedOn, c.Id })
            .HasName("pk_game_bet_event_sources");

        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.GameProviderId, c.GameId, c.WalletId, c.ExternalBetId })
            .HasDatabaseName("ix_game_bet_event_sources");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.GameProviderId })
            .HasDatabaseName("ix_game_bet_event_sources_g_p");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.GameProviderId, c.BetState })
            .HasDatabaseName("ix_game_bet_event_sources_g_p_bet_state");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.GameProviderId, c.BetState, c.Id })
            .HasDatabaseName("ix_game_bet_event_sources_g_p_bet_state_id");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.GameProviderId, c.Id })
            .HasDatabaseName("ix_game_bet_event_sources_g_p_id");

        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.BrandId })
            .HasDatabaseName("ix_game_bet_event_sources_brand_id");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.BrandId, c.BetState })
            .HasDatabaseName("ix_game_bet_event_sources_brand_id_bet_state");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.BrandId, c.BetState, c.Id })
            .HasDatabaseName("ix_game_bet_event_sources_brand_id_bet_state_id");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.BrandId, c.Id })
            .HasDatabaseName("ix_game_bet_event_sources_brand_id_id");

        _ = builder.Property(c => c.Id)
            .IsRequired()
            .HasComment("識別碼");
        _ = builder.Property(c => c.GameProviderId)
            .IsRequired()
            .HasComment("遊戲供應商識別碼");
        _ = builder.Property(c => c.GameProviderConfigurationId)
            .IsRequired()
            .HasComment("遊戲供應商設定識別碼");
        _ = builder.Property(c => c.GameId)
            .IsRequired()
            .HasComment("遊戲識別碼");
        _ = builder.Property(c => c.ResellerId)
            .IsRequired()
            .HasComment("公司識別碼");
        _ = builder.Property(c => c.LicenseeId)
            .IsRequired()
            .HasComment("分公司識別碼");
        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");
        _ = builder.Property(c => c.PlayerCode)
            .IsRequired()
            .HasComment("玩家代碼");
        _ = builder.Property(c => c.CurrencyCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("貨幣代碼");
        _ = builder.Property(c => c.WalletId)
            .IsRequired()
            .HasComment("錢包識別碼");
        _ = builder.Property(c => c.ExternalRoundId)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("三方局/回合識別碼");
        _ = builder.Property(c => c.ExternalBetId)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("三方投注單別碼");
        _ = builder.Property(c => c.ExternalCreatedOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方下注/創建時間");
        _ = builder.Property(c => c.ExternalClosedOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方結算/結束時間");
        _ = builder.Property(c => c.ExternalPayoffOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方派彩時間");
        _ = builder.Property(c => c.ExternalResettleOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方重新結算時間");
        _ = builder.Property(c => c.BetState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("注單狀態");
        _ = builder.Property(c => c.BetType)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("注單類型");
        _ = builder.Property(c => c.FreeGameState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("免費遊戲狀態");
        _ = builder.Property(c => c.GambleState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("博取遊戲狀態");
        _ = builder.Property(c => c.CashoutState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("兌現狀態");
        _ = builder.Property(c => c.JackpotState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("彩金狀態");
        _ = builder.Property(c => c.ResettleState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("重新結算狀態");
        _ = builder.Property(b => b.CurrencyRatio)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("貨幣比例");
        _ = builder.Property(b => b.Bet)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("下注");
        _ = builder.Property(b => b.ValidBet)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("實際/有效下注");
        _ = builder.Property(b => b.Settle)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("結算(包含本金)");
        _ = builder.Property(b => b.Commission)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("傭金");
        _ = builder.Property(b => b.Turnover)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("有效投注");
        _ = builder.Property(b => b.WinLoss)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("玩家損益/淨利");
        _ = builder.Property(b => b.Jackpot)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("彩金");
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
        _ = builder.Property(c => c.AdditionalData)
            .IsRequired()
            .HasColumnType(ColumnTypes.Jsonb)
            .HasDefaultValue("{}")
            .HasComment("附加數據");
    }
}

