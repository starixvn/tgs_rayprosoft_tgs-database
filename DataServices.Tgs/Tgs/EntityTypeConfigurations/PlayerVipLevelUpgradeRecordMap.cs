using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelUpgradeRecordMap : IEntityTypeConfiguration<PlayerVipLevelUpgradeRecord>
{
    void IEntityTypeConfiguration<PlayerVipLevelUpgradeRecord>.Configure(EntityTypeBuilder<PlayerVipLevelUpgradeRecord> builder)
    {
        _ = builder.ToTable("player_vip_level_upgrade_records");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_upgrade_records");
        _ = builder.Property(b => b.Id)
        .IsRequired();
        _ = builder.Property(b => b.PlayerVipLevelSnapshotId)
            .IsRequired();
        _ = builder.Property(b => b.BrandId)
            .IsRequired();
        _ = builder.Property(b => b.ExecutionOn)
            .IsRequired();
        _ = builder.Property(c => c.Status)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();
        _ = builder.HasIndex(b => b.BrandId)
            .HasDatabaseName("ix_player_vip_level_upgrade_records_brand_id");
        _ = builder.HasIndex(b => b.PlayerVipLevelSnapshotId)
            .HasDatabaseName("ix_player_vip_level_upgrade_records_player_vip_level_snapshot_id");
    }
}
