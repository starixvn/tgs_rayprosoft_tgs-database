using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class MarketTypeMap : IEntityTypeConfiguration<MarketType>
{
    void IEntityTypeConfiguration<MarketType>.Configure(EntityTypeBuilder<MarketType> builder)
    {
        _ = builder.ToTable("market_types");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_market_types");

        _ = builder.HasAlternateKey(e => new { e.GameProviderId, e.Code })
            .HasName("ak_market_types_game_provider_id_code");

        _ = builder.Property(e => e.Code)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(e => e.ExternalId)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.HasOne(e => e.GameProvider)
            .WithMany(e => e.MarketTypes)
            .HasForeignKey(e => e.GameProviderId)
            .HasConstraintName("fk_market_types_game_providers_game_provider_id");
    }
}
