using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelUpgradePromotionMap : IEntityTypeConfiguration<PlayerVipLevelUpgradePromotion>
{
    void IEntityTypeConfiguration<PlayerVipLevelUpgradePromotion>.Configure(EntityTypeBuilder<PlayerVipLevelUpgradePromotion> builder)
    {
        _ = builder.ToTable("player_vip_level_upgrade_promotions");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_upgrade_promotions");
        _ = builder.Property(b => b.Id)
        .IsRequired();
        _ = builder.Property(b => b.VipId)
            .IsRequired();
        _ = builder.Property(b => b.PlayerVipLevelSnapshotId)
            .IsRequired();
        _ = builder.Property(b => b.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();
        _ = builder.Property(b => b.Amount)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();
        _ = builder.HasIndex(b => b.VipId)
            .HasDatabaseName("ix_player_vip_level_upgrade_promotions_vip_id");
        _ = builder.HasIndex(b => b.PlayerVipLevelSnapshotId)
            .HasDatabaseName("ix_player_vip_level_upgrade_promotions_player_vip_level_snapshot_id");
        _ = builder.HasIndex(b => new { b.VipId, b.PlayerCode })
            .HasDatabaseName("ix_player_vip_level_upgrade_promotions_vip_id_player_code");
    }
}
