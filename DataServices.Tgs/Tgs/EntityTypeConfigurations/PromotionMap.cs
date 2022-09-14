using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionMap : IEntityTypeConfiguration<Promotion>
{
    void IEntityTypeConfiguration<Promotion>.Configure(EntityTypeBuilder<Promotion> builder)
    {
        _ = builder.ToTable("promotions");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_promotions_id");

        _ = builder.Property(c => c.Name)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.From)
            .IsRequired();

        _ = builder.Property(c => c.To)
            .IsRequired();

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.PromotionType)
            .IsRequired();

        _ = builder.Property(c => c.Unlimited)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.GameType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired(false);

        _ = builder.Property(c => c.BonusAmountLimit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.AmountUsed)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.AmountUsedSnapshotId)
            .IsRequired(false);

        _ = builder.Property(c => c.Percentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.TotalAmountLimit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.TurnoverMultiple)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SubSubject)
            .HasMaxLength(2048);

        _ = builder.Property(e => e.DesktopBanner)
            .HasMaxLength(128);

        _ = builder.Property(e => e.MobileBanner)
            .HasMaxLength(128);

        _ = builder.Property(c => c.Localization)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(p => p.CampaignDetail)
            .IsRequired()
            .HasColumnType(ColumnTypes.Jsonb)
            .HasDefaultValue("{}");

        _ = builder.Property(p => p.DisplayOrder)
            .HasDefaultValue(1);

        _ = builder.HasOne(p => p.Brand)
            .WithMany()
            .HasForeignKey(p => p.BrandId)
            .HasConstraintName("fk_promotions_brands_brand_id");

        _ = builder.HasMany(p => p.PromotionGameProviders)
            .WithOne(p => p.Promotion)
            .HasForeignKey(p => p.PromotionId);

        _ = builder.HasMany(p => p.PromotionVipLevels)
            .WithOne(p => p.Promotion)
            .HasForeignKey(p => p.PromotionId);

        _ = builder.HasMany(p => p.PromotionParticipants)
            .WithOne(p => p.Promotion)
            .HasForeignKey(p => p.PromotionId);

        _ = builder.HasIndex(c => c.BrandId)
            .HasDatabaseName("ix_promotions_brand_id");
    }
}
