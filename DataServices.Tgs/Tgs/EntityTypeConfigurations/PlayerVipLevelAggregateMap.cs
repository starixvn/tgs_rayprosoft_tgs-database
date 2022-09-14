using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelAggregateMap : IEntityTypeConfiguration<PlayerVipLevelAggregate>
{
    void IEntityTypeConfiguration<PlayerVipLevelAggregate>.Configure(EntityTypeBuilder<PlayerVipLevelAggregate> builder)
    {
        _ = builder.ToTable("player_vip_level_aggregates");

        _ = builder.HasKey(b => new { b.BrandId, b.PlayerCode, b.FromOn, b.ToOn })
            .HasName("pk_player_vip_level_aggregates");
        _ = builder.Property(b => b.BrandId)
            .IsRequired();
        _ = builder.Property(b => b.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();
        _ = builder.Property(b => b.FromOn)
            .IsRequired();
        _ = builder.Property(b => b.ToOn)
            .IsRequired();
        _ = builder.Property(b => b.DepositAmount)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(b => b.Turnover)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();
        _ = builder.Property(b => b.UpdateOn)
            .IsRequired();

        _ = builder.HasIndex(b => new { b.PlayerCode, b.FromOn, b.ToOn })
            .HasDatabaseName("ix_player_vip_level_aggregates_player_code");
    }
}
