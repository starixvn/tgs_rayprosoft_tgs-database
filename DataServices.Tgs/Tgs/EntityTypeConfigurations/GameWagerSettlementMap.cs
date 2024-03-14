using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerSettlementMap : IEntityTypeConfiguration<GameWagerSettlement>
{
    void IEntityTypeConfiguration<GameWagerSettlement>.Configure(EntityTypeBuilder<GameWagerSettlement> builder)
    {
        _ = builder.ToTable("game_wager_settlements");

        _ = builder
            .HasKey(c => new { c.ExternalCreatedOn, c.GameWagerPrimaryId })
            .HasName("pk_game_wager_settlements");

        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.Id })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.WagerState })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on_wager_state");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.ExternalClosedOn })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on_e_closed_on");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.ExternalPayoffOn })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on_e_payoff_on");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.ExternalResettleOn })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on_e_resettle_on");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.ClosedOn })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on_closed_on");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.UpdatedOn })
            .HasDatabaseName("ix_game_wager_settlements_e_c_on_updated_on");

        _ = builder.Property(c => c.Id)
            .IsRequired()
            .HasComment("識別碼");
        _ = builder.Property(c => c.GameWagerPrimaryId)
            .IsRequired()
            .HasComment("遊戲投注主要識別碼");
        _ = builder.Property(c => c.WagerState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("投注狀態");
        _ = builder.Property(c => c.WagerType)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("投注類型");
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
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
        _ = builder.Property(c => c.ClosedOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("結束時間");
        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("修改時間");
        _ = builder.Property(c => c.ResetState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("重置狀態");
        _ = builder.Property(c => c.ResetOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("重置時間");
    }
}
