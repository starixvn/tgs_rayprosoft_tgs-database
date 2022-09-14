using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerDailyRegisterStatisticsMap : IEntityTypeConfiguration<PlayerDailyRegisterStatistics>
{
    public void Configure(EntityTypeBuilder<PlayerDailyRegisterStatistics> builder)
    {
        _ = builder.ToTable("player_daily_register_statistics");

        _ = builder.HasKey(prs => new { prs.ReportDate, prs.PlayerCode });

        _ = builder.Property(prs => prs.LastLoginOn)
            .HasColumnType("timestamptz");
        _ = builder.Property(prs => prs.DailyLoginCount)
            .IsRequired();
        _ = builder.Property(prs => prs.TotalLoginCount)
            .IsRequired();
    }
}
