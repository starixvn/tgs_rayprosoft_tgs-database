using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionGameProviderMap : IEntityTypeConfiguration<PromotionGameProvider>
{
    void IEntityTypeConfiguration<PromotionGameProvider>.Configure(EntityTypeBuilder<PromotionGameProvider> builder)
    {
        _ = builder.ToTable("promotion_game_providers");

        _ = builder.HasKey(b => new { b.PromotionId, b.GameProviderId })
            .HasName("pk_promotion_game_providers");

        _ = builder.HasOne(p => p.Promotion)
            .WithMany(p => p.PromotionGameProviders)
            .HasForeignKey(p => p.PromotionId)
            .HasConstraintName("fk_promotion_game_provider_promotion_id");

        _ = builder.HasOne(p => p.GameProvider)
            .WithMany()
            .HasForeignKey(p => p.GameProviderId)
            .HasConstraintName("fk_promotion_game_provider_game_provider_id");

        _ = builder.HasIndex(c => c.GameProviderId)
            .HasDatabaseName("ix_promotion_game_provider_game_provider_id");
    }
}
