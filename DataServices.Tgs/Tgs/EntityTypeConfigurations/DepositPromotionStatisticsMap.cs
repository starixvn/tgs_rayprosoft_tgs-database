using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class DepositPromotionStatisticsMap : IEntityTypeConfiguration<DepositPromotionStatistics>
{
    public void Configure(EntityTypeBuilder<DepositPromotionStatistics> builder)
    {
        _ = builder.ToTable("deposit_promotion_statistics");

        _ = builder.HasKey(dp => new { dp.PromotionId, dp.PlayerCode });

        _ = builder.Property(dp => dp.ProcessedDate)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(dp => dp.TotalDepositCount)
            .IsRequired();
    }
}