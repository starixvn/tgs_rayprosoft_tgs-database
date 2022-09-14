using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelBirthdayPromotionMap : IEntityTypeConfiguration<PlayerVipLevelBirthdayPromotion>
{
    void IEntityTypeConfiguration<PlayerVipLevelBirthdayPromotion>.Configure(
        EntityTypeBuilder<PlayerVipLevelBirthdayPromotion> builder)
    {
        _ = builder.ToTable("player_vip_level_birthday_promotions");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_birthday_promotions");
        _ = builder.Property(b => b.Id)
        .IsRequired();
        _ = builder.Property(b => b.VipId)
            .IsRequired();
        _ = builder.Property(b => b.PlayerVipLevelSnapshotId)
            .IsRequired();
        _ = builder.Property(b => b.BrandId)
            .IsRequired();
        _ = builder.Property(b => b.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();
        _ = builder.Property(b => b.Amount)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(b => b.ExecuteYear)
            .IsRequired();
        _ = builder.Property(b => b.Birthday)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => new
        {
            b.PlayerCode,
            b.ExecuteYear
        })
            .HasDatabaseName("ix_player_vip_level_birthday_promotions_player_code_execute_year");

        _ = builder.HasIndex(b => b.Birthday)
            .HasDatabaseName("ix_player_vip_level_birthday_promotions_birthday");
    }
}
