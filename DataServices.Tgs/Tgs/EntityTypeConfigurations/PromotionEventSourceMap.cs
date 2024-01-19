using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionEventSourceMap : IEntityTypeConfiguration<PromotionEventSource>
{
    public void Configure(EntityTypeBuilder<PromotionEventSource> builder)
    {
        _ = builder.ToTable("promotion_event_source");

        _ = builder.HasKey(pes => pes.Id);

        _ = builder.Property(pes => pes.PromotionId)
            .IsRequired();

        _ = builder.Property(pes => pes.ChangeSets)
            .HasColumnType("jsonb")
            .IsRequired();

        _ = builder.Property(pes => pes.Action)
            .IsRequired();

        _ = builder.Property(pes => pes.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();

        _ = builder.Property(pes => pes.ModifyUser);
    }
}
