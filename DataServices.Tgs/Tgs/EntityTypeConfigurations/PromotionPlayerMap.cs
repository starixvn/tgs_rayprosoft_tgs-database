using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionPlayerMap : IEntityTypeConfiguration<PromotionPlayer>
{
    void IEntityTypeConfiguration<PromotionPlayer>.Configure(EntityTypeBuilder<PromotionPlayer> builder)
    {
        _ = builder.ToTable("promotion_players");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_promotion_player_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired();

        _ = builder.Property(c => c.PromotionBonusId)
            .IsRequired();

        _ = builder.Property(c => c.BonusAmount)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.BucketAmountByManual)
            .HasPrecision(18, 6);

        _ = builder.Property(e => e.SentOn)
            .IsRequired(false);

        _ = builder.HasOne(x => x.Player)
            .WithMany()
            .HasForeignKey(x => x.PlayerCode)
            .HasConstraintName("fk_promotion_bonus_player_code");

        _ = builder.HasIndex(c => new { c.PlayerCode })
            .HasDatabaseName("ix_promotion_player_promotion_id");

        _ = builder.HasIndex(c => new { c.PlayerCode, c.PromotionBonusId })
            .HasDatabaseName("ix_promotion_player_multiple_keys");
    }
}
