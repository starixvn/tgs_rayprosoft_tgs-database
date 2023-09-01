using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class VipLevelMap : BaseConfiguration, IEntityTypeConfiguration<VipLevel>
{
    void IEntityTypeConfiguration<VipLevel>.Configure(EntityTypeBuilder<VipLevel> builder)
    {
        _ = builder.ToTable("vip_levels");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_vip_levels");

        _ = builder.Property(c => c.LevelUpAccumulateBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LevelUpAccumulateDeposit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LevelKeepAccumulateBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LevelKeepAccumulateDeposit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.BirthReward)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.PromotionReward)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.QuarterlyReward)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.WithdrawTransactionsPerDay)
            .IsRequired()
            .HasDefaultValueSql("-1");

        _ = builder.Property(c => c.WithdrawTotalAmountPerDay)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValueSql("-1");

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder
            .HasOne(c => c.Brand)
            .WithMany(c => c.VipLevels)
            .HasForeignKey(c => c.BrandId)
            .HasConstraintName("fk_vip_levels_brands_brand_id")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(c => c.BrandId)
            .HasDatabaseName("ix_vip_levels_brand_id");
    }
}
