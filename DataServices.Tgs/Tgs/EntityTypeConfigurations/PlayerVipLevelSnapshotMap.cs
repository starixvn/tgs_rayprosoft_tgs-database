using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelSnapshotMap : IEntityTypeConfiguration<PlayerVipLevelSnapshot>
{
    void IEntityTypeConfiguration<PlayerVipLevelSnapshot>.Configure(EntityTypeBuilder<PlayerVipLevelSnapshot> builder)
    {
        _ = builder.ToTable("player_vip_level_snapshots");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_snapshots");
        _ = builder.Property(b => b.Id)
        .IsRequired();
        _ = builder.Property(b => b.BrandId)
            .IsRequired();
        _ = builder.Property(b => b.SnapshotOn)
            .IsRequired();
        _ = builder.Property(c => c.Data)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();
        _ = builder.HasIndex(b => b.BrandId)
            .HasDatabaseName("ix_player_vip_level_snapshots_brand_id");
    }
}
