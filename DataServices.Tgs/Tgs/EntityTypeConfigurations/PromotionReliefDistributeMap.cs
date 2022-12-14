using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;
internal class PromotionReliefDistributeMap : IEntityTypeConfiguration<PromotionReliefDistribute>
{
    public void Configure(EntityTypeBuilder<PromotionReliefDistribute> builder)
    {
        _ = builder.ToTable("promotion_relief_distributes");

        _ = builder.HasKey(prd => prd.Id);

        _ = builder.Property(prd => prd.DistributeDate)
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
