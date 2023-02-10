using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBucketCleanEventSourceMap : IEntityTypeConfiguration<PlayerBucketCleanEventSource>
{
    public void Configure(EntityTypeBuilder<PlayerBucketCleanEventSource> builder)
    {
        _ = builder.ToTable("player_bucket_clean_event_source");

        _ = builder.HasKey(es => es.Id);

        _ = builder.Property(es => es.ChangeSets)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(es => es.FormId)
            .IsRequired();
        _ = builder.Property(es => es.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}
