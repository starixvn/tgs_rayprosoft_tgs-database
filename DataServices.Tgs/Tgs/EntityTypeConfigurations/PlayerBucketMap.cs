using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBucketMap : IEntityTypeConfiguration<PlayerBucket>
{
    void IEntityTypeConfiguration<PlayerBucket>.Configure(EntityTypeBuilder<PlayerBucket> builder)
    {
        _ = builder.ToTable("player_buckets");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_player_buckets");

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired();

        _ = builder.Property(c => c.BucketAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CurrentBucketAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.BucketType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.SnapshotId);

        _ = builder.HasIndex(c => c.PlayerCode)
            .HasDatabaseName("ix_player_buckets_player_code");
    }
}
