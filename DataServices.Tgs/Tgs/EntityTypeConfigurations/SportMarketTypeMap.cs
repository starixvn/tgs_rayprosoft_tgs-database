using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class SportMarketTypeMap : IEntityTypeConfiguration<SportMarketType>
{
    void IEntityTypeConfiguration<SportMarketType>.Configure(EntityTypeBuilder<SportMarketType> builder)
    {
        _ = builder.ToTable("sport_market_types");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_sport_market_types");

        _ = builder.HasAlternateKey(e => new { e.SportTypeId, e.MarketTypeId })
            .HasName("ak_sport_market_types_sport_type_id_market_type_id");

        _ = builder.HasOne(e => e.SportType)
            .WithMany(e => e.MarketTypes)
            .HasForeignKey(e => e.SportTypeId)
            .HasConstraintName("fk_sport_market_types_sport_types_sport_type_id")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasOne(e => e.MarketType)
            .WithMany(e => e.SportTypes)
            .HasForeignKey(e => e.MarketTypeId)
            .HasConstraintName("fk_sport_market_types_market_types_market_type_id")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(e => e.MarketTypeId)
            .HasDatabaseName("ix_sport_market_types_market_type_id");
    }
}
