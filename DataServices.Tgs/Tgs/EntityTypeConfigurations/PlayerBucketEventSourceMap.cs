using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class PlayerBucketEventSourceMap : IEntityTypeConfiguration<PlayerBucketEventSource>
{
    public void Configure(EntityTypeBuilder<PlayerBucketEventSource> builder)
    {
        _ = builder.ToTable("player_bucket_event_source");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_player_bucket_event_source");

        _ = builder.Property(e => e.BucketId)
            .IsRequired();
        _ = builder.Property(e => e.FillType)
            .IsRequired();
        _ = builder.Property(e => e.ExternalId);
        _ = builder.Property(e => e.ChangeAmount)
            .IsRequired();
        _ = builder.Property(e => e.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired()
            .HasDefaultValueSql("Now()");
        _ = builder.Property(e => e.ChangeSets)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();
    }
}
