using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionRebateDailyStatisticsMap : IEntityTypeConfiguration<PromotionRebateDailyStatistics>
{
    public void Configure(EntityTypeBuilder<PromotionRebateDailyStatistics> builder)
    {
        _ = builder.ToTable("promotion_rebate_daily_statistics");

        _ = builder.HasKey(prds => new
        {
            prds.ReportDate,
            prds.BrandId,
            prds.PromotionId,
            prds.PlayerCode
        });

        _ = builder.Property(prds => prds.RebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();
    }
}
