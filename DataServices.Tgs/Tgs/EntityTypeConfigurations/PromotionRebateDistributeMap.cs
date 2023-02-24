using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionRebateDistributeMap : IEntityTypeConfiguration<PromotionRebateDistribute>
{
    public void Configure(EntityTypeBuilder<PromotionRebateDistribute> builder)
    {
        _ = builder.ToTable("promotion_rebate_distributes");

        _ = builder.HasKey(prd => prd.Id);

        _ = builder.Property(prd => prd.DistributeFrom)
            .IsRequired();
        _ = builder.Property(prd => prd.DistributeTo)
            .IsRequired();
        _ = builder.Property(prd => prd.BrandId)
            .IsRequired();
        _ = builder.Property(prd => prd.PromotionId)
            .IsRequired();
        _ = builder.Property(prd => prd.PlayerCode)
            .IsRequired();
        _ = builder.Property(prd => prd.Bonus)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(prd => prd.BucketAmount)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(prd => prd.Settings)
            .HasColumnType("jsonb")
            .IsRequired()
            .HasDefaultValueSql("'{}'");
        _ = builder.Property(prd => prd.Status)
            .IsRequired();
        _ = builder.Property(prd => prd.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}
