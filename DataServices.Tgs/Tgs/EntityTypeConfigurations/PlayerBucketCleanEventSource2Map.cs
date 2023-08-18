#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBucketCleanEventSource2Map : IEntityTypeConfiguration<PlayerBucketCleanEventSource2>
{
    public void Configure(EntityTypeBuilder<PlayerBucketCleanEventSource2> builder)
    {
        _ = builder.ToTable("player_bucket_clean_event_source2");

        _ = builder.HasKey(es => es.Id)
            .HasName("pk_player_bucket_clean_event_source2");

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
