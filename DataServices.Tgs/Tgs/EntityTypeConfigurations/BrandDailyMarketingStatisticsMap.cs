using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandDailyMarketingStatisticsMap : BaseConfiguration, IEntityTypeConfiguration<BrandDailyMarketingStatistics>
{
    public void Configure(EntityTypeBuilder<BrandDailyMarketingStatistics> builder)
    {
        _ = builder.ToTable("brand_daily_marketing_statistics");

        _ = builder.HasKey(b => new { b.ReportDate, b.BrandId });

        _ = builder.Property(b => b.ReportDate)
            .IsRequired();
        _ = builder.Property(b => b.BrandId)
            .IsRequired();

        _ = builder
            .Property(a => a.DirectlyPlayerRegisterCount)
            .HasComment("無直屬代理的玩家註冊人數");

        _ = builder
            .Property(a => a.DirectlyPlayerGamingCount)
            .HasComment("無直屬代理的玩家遊戲人數");

        _ = builder
            .Property(a => a.TotalPlayerRegisterCount)
            .HasComment("玩家總註冊人數");

        _ = builder
            .Property(a => a.TotalPlayerGamingCount)
            .HasComment("玩家總遊戲人數");
    }
}
