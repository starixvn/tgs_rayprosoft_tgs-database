using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionMilestoneMap : IEntityTypeConfiguration<PromotionMilestone>
{
    public void Configure(EntityTypeBuilder<PromotionMilestone> builder)
    {
        _ = builder.ToTable("promotion_milestones");

        _ = builder.HasKey(prd => prd.Id);

        _ = builder.Property(prd => prd.BrandId)
            .IsRequired();

        _ = builder.Property(prd => prd.PromotionId)
            .IsRequired();

        _ = builder.Property(prd => prd.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(prd => prd.Bonus)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(prd => prd.BucketAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(prd => prd.DepositAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(prd => prd.ValidBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(prd => prd.CreatedOn)
            .IsRequired();

        _ = builder
            .HasOne(e => e.PromotionDistribute)
            .WithOne()
            .HasForeignKey<PromotionMilestone>(e => e.PromotionDistributeId);

        _ = builder.HasIndex(b => new
            {
                b.BrandId,
                b.PromotionId,
                b.PlayerCode
            })
            .HasDatabaseName("ix_promotion_milestone_brand_id_promotion_id_player_code");
    }
}
