using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionReliefDailyStatisticsMap : IEntityTypeConfiguration<PromotionReliefDailyStatistics>
{
    public void Configure(EntityTypeBuilder<PromotionReliefDailyStatistics> builder)
    {
        _ = builder.ToTable("promotion_relief_daily_statistics");

        _ = builder.HasKey(prds => new
        {
            prds.ReportDate,
            prds.BrandId,
            prds.PromotionId,
            prds.PlayerCode
        });

        _ = builder.Property(prds => prds.BucketAmount)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(prds => prds.Settings)
            .HasColumnType("jsonb")
            .IsRequired()
            .HasDefaultValueSql("'{}'");
        _ = builder.Property(prds => prds.TotalWinLoss)
            .HasPrecision(18, 6)
            .IsRequired();
    }
}
