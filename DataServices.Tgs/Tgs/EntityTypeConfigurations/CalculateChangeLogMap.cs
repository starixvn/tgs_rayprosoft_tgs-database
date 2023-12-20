using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class CalculateChangeLogMap : IEntityTypeConfiguration<CalculateChangeLog>
{
    public void Configure(EntityTypeBuilder<CalculateChangeLog> builder)
    {
        _ = builder.ToTable("calculate_change_log");

        _ = builder.HasKey(c => c.Id);

        _ = builder.Property(c => c.Change)
            .IsRequired();
        _ = builder.Property(c => c.Balance)
            .IsRequired();
        _ = builder.Property(c => c.RecordedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(c => c.CalculateId)
            .IsRequired();
    }
}
