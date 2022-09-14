using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionBonusMap : IEntityTypeConfiguration<PromotionBonus>
{
    void IEntityTypeConfiguration<PromotionBonus>.Configure(EntityTypeBuilder<PromotionBonus> builder)
    {
        _ = builder.ToTable("promotion_bonuses");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_promotion_bonus_id");

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.PromotionId)
            .IsRequired();

        _ = builder.Property(c => c.From)
            .IsRequired();

        _ = builder.Property(c => c.To)
            .IsRequired();

        _ = builder.Property(c => c.PromotionType)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.GameType)
            .HasColumnType(ColumnTypes.SmallInt);

        _ = builder.Property(c => c.TotalAmountLimit)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.Percentage)
            .HasPrecision(9, 6);

        _ = builder.Property(c => c.BonusAmountLimit)
            .HasPrecision(18, 6);

        _ = builder.Property(e => e.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.Detail)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.HasOne(x => x.Promotion)
            .WithMany()
            .HasForeignKey(x => x.PromotionId)
            .HasConstraintName("fk_promotion_bonus_promotion_id");

        _ = builder.HasMany(x => x.PromotionPlayers)
            .WithOne(x => x.PromotionBonus)
            .HasForeignKey(x => x.PromotionBonusId)
            .HasConstraintName("fk_promotion_bonus_promotion_brand_id");

        _ = builder.HasIndex(c => new { c.BrandId })
            .HasDatabaseName("ix_promotion_bonus_brand_id");

        _ = builder.HasIndex(c => new { c.PromotionId })
            .HasDatabaseName("ix_promotion_bonus_promotion_id");

        _ = builder.HasIndex(c => new { c.PromotionId, c.From, c.To })
            .HasDatabaseName("ix_promotion_bonus_promotion_id_from_to");

        _ = builder.HasIndex(c => new { c.BrandId, c.From, c.To })
            .HasDatabaseName("ix_promotion_bonus_brand_id_from_to");
    }
}
