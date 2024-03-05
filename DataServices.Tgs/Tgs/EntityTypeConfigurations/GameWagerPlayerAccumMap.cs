using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerPlayerAccumMap : IEntityTypeConfiguration<GameWagerPlayerAccum>
{
    void IEntityTypeConfiguration<GameWagerPlayerAccum>.Configure(EntityTypeBuilder<GameWagerPlayerAccum> builder)
    {
        _ = builder.ToTable("game_wager_player_accums");

        _ = builder
            .HasKey(c => new { c.AccumOn, c.ResellerId, c.LicenseeId, c.BrandId, c.PlayerCode })
            .HasName("pk_game_wager_player_accums");

        _ = builder
            .HasIndex(c => new { c.AccumOn })
            .HasDatabaseName("ix_game_wager_player_accums_accum_on");
        _ = builder
            .HasIndex(c => new { c.AccumOn, c.ResellerId })
            .HasDatabaseName("ix_game_wager_player_accums_reseller_id");
        _ = builder
            .HasIndex(c => new { c.AccumOn, c.LicenseeId })
            .HasDatabaseName("ix_game_wager_player_accums_licensee_id");
        _ = builder
            .HasIndex(c => new { c.AccumOn, c.BrandId })
            .HasDatabaseName("ix_game_wager_player_accums_brand_id");
        _ = builder
            .HasIndex(c => new { c.AccumOn, c.PlayerCode })
            .HasDatabaseName("ix_game_wager_player_accums_player_code");

        _ = builder.Property(c => c.AccumOn)
            .IsRequired()
            .HasComment("累積時間");
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
            .HasMaxLength(16)
            .HasComment("玩家代碼");
        _ = builder.Property(b => b.Count)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("筆數");
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
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("修改時間");
    }
}
