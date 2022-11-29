using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class RebatePromotionJoinPlayerMap : IEntityTypeConfiguration<RebatePromotionJoinPlayer>
{
    public void Configure(EntityTypeBuilder<RebatePromotionJoinPlayer> builder)
    {
        _ = builder.ToTable("rebate_promotion_join_players");

        _ = builder.HasKey(rp => new { rp.PromotionId, rp.PlayerCode });

        _ = builder.Property(rp => rp.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(rp => rp.PlayerCode)
            .HasConstraintName("fk_players_rebate_promotion_join_players")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<Promotion>()
            .WithMany()
            .HasForeignKey(rp => rp.PromotionId)
            .HasConstraintName("fk_promotions_rebate_promotion_join_players")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
