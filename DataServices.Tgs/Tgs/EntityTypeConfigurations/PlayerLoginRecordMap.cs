using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerLoginRecordMap : IEntityTypeConfiguration<PlayerLoginRecord>
{
    void IEntityTypeConfiguration<PlayerLoginRecord>.Configure(EntityTypeBuilder<PlayerLoginRecord> builder)
    {
        _ = builder.ToTable("player_login_records");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_login_records");

        _ = builder.Property(b => b.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(b => b.BrandId)
            .IsRequired();

        _ = builder.Property(b => b.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.PlatformType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.Property(b => b.ExpiredOn)
            .IsRequired();

        _ = builder.HasOne(b => b.Player)
            .WithMany(b => b.PlayerLoginRecords)
            .HasForeignKey(b => b.PlayerCode)
            .HasConstraintName("fk_player_login_records_players_player_code")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(b => b.PlayerCode)
            .HasDatabaseName("ix_player_login_records_player_code");

        _ = builder.HasOne(b => b.Brand)
            .WithMany(b => b.PlayerLoginRecords)
            .HasForeignKey(b => b.BrandId)
            .HasConstraintName("fk_player_login_records_brands_brand_id")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(b => b.BrandId)
            .HasDatabaseName("ix_player_login_records_brand_id");
    }
}
