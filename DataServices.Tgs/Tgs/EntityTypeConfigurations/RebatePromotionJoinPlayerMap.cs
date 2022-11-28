using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class RebatePromotionJoinPlayerMap : IEntityTypeConfiguration<RebatePromotionJoinPlayer>
{
    public void Configure(EntityTypeBuilder<RebatePromotionJoinPlayer> builder)
    {
        builder.ToTable("rebate_promotion_join_players");

        builder.HasKey(rp => new { rp.PromotionId, rp.PlayerCode });

        builder.Property(rp => rp.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(rp => rp.PlayerCode)
            .HasConstraintName("fk_players_rebate_promotion_join_players")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Promotion>()
            .WithMany()
            .HasForeignKey(rp => rp.PromotionId)
            .HasConstraintName("fk_promotions_rebate_promotion_join_players")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
