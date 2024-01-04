using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class CalculateMap : IEntityTypeConfiguration<Calculate>
{
    public void Configure(EntityTypeBuilder<Calculate> builder)
    {
        _ = builder.ToTable("calculate");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_calculate");

        _ = builder.Property(c => c.Balance)
            .IsRequired();
        _ = builder.Property(c => c.SnapshotId)
            .IsRequired();
        _ = builder.Property(c => c.Deleted)
            .IsRequired();
    }
}
