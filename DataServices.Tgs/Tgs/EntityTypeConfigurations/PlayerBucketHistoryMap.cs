using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBucketHistoryMap : IEntityTypeConfiguration<PlayerBucketHistory>
{
    void IEntityTypeConfiguration<PlayerBucketHistory>.Configure(EntityTypeBuilder<PlayerBucketHistory> builder)
    {
        _ = builder.ToTable("player_bucket_histories");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_player_bucket_histories");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(c => c.PlayerBucketId)
            .IsRequired();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(b => b.Turnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.From)
            .IsRequired();

        _ = builder.Property(c => c.To)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.RoundData)
            .HasColumnType(ColumnTypes.Jsonb)
            .HasDefaultValue("{}")
            .IsRequired();

        _ = builder.HasIndex(c => c.PlayerCode)
            .HasDatabaseName("ix_player_bucket_histories_player_code");
    }
}
