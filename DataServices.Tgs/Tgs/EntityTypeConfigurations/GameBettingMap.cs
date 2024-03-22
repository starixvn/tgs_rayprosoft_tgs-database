using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.DataServices.Base;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameBettingMap : IEntityTypeConfiguration<GameBetting>
{
    void IEntityTypeConfiguration<GameBetting>.Configure(EntityTypeBuilder<GameBetting> builder)
    {
        _ = builder.ToTable("game_betting");

        _ = builder
            .HasKey(c => new { c.GameProviderId, c.GameId, c.WalletId, c.ExternalBetId })
            .HasName("pk_game_betting");

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
        _ = builder.Property(c => c.BetType)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("注單類型");
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
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("修改時間");
        _ = builder.Property(c => c.AdditionalData)
            .IsRequired()
            .HasColumnType(ColumnTypes.Jsonb)
            .HasDefaultValue("{}")
            .HasComment("附加數據");
    }
}

