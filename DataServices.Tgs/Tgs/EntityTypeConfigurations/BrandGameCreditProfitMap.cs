using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGameCreditProfitMap : IEntityTypeConfiguration<BrandGameCreditProfit>
{
    void IEntityTypeConfiguration<BrandGameCreditProfit>.Configure(EntityTypeBuilder<BrandGameCreditProfit> builder)
    {
        _ = builder.ToTable("brand_game_credit_profits");

        _ = builder
            .HasKey(c => new { c.BrandId, c.Month, c.GameProviderId })
            .HasName("pk_brand_game_credit_profits");

        _ = builder
            .HasIndex(c => new { c.BrandId, c.Month })
            .HasDatabaseName("ix_brand_game_credit_profits_brand_id");

        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");
        _ = builder.Property(c => c.Month)
            .IsRequired()
            .HasDefaultValueSql("'1990-01-01':: date")
            .HasComment("月份");
        _ = builder.Property(c => c.GameProviderId)
            .IsRequired()
            .HasComment("遊戲供應商識別碼");
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
        _ = builder.Property(b => b.ProfitAmount)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("利潤額度");
    }
}

