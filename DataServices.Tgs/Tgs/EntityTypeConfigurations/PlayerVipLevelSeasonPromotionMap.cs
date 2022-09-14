using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelSeasonPromotionMap : IEntityTypeConfiguration<PlayerVipLevelSeasonPromotion>
{
    void IEntityTypeConfiguration<PlayerVipLevelSeasonPromotion>.Configure(EntityTypeBuilder<PlayerVipLevelSeasonPromotion> builder)
    {
        _ = builder.ToTable("player_vip_level_season_promotions");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_season_promotions");
        _ = builder.Property(b => b.Id)
        .IsRequired();
        _ = builder.Property(b => b.VipId)
            .IsRequired();
        _ = builder.Property(b => b.PlayerVipLevelSnapshotId)
            .IsRequired();
        _ = builder.Property(b => b.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();
        _ = builder.Property(b => b.SeasonOn)
            .IsRequired();
        _ = builder.Property(b => b.FromOn)
            .IsRequired();
        _ = builder.Property(b => b.ToOn)
            .IsRequired();
        _ = builder.Property(b => b.Amount)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();
        _ = builder.HasIndex(b => b.VipId)
            .HasDatabaseName("ix_player_vip_level_season_promotions_vip_id");
        _ = builder.HasIndex(b => b.PlayerVipLevelSnapshotId)
            .HasDatabaseName("ix_player_vip_level_season_promotions_player_vip_level_snapshot_id");
    }
}
