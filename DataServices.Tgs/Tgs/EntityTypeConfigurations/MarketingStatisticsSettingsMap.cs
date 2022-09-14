using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class MarketingStatisticsSettingsMap : IEntityTypeConfiguration<MarketingStatisticsSettings>
{
    public void Configure(EntityTypeBuilder<MarketingStatisticsSettings> builder)
    {
        _ = builder.ToTable("marketing_statistics_settings");

        _ = builder.HasKey(b => b.RecordKey);

        _ = builder.Property(b => b.RecordKey)
            .IsRequired();
        _ = builder.Property(b => b.ProcessedTime)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}
