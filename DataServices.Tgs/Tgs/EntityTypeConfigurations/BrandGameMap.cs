using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGameMap : IEntityTypeConfiguration<BrandGame>
{
    void IEntityTypeConfiguration<BrandGame>.Configure(EntityTypeBuilder<BrandGame> builder)
    {
        _ = builder.ToTable("brand_games");

        _ = builder.HasKey(bg => bg.Id)
            .HasName("pk_brand_games");

        _ = builder.HasAlternateKey(bg => new { bg.BrandId, bg.GameId })
            .HasName("ak_brand_games_brand_id_game_id");

        _ = builder.Property(bg => bg.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(bg => bg.Tag)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.EffectiveBettingPercentage)
            .HasPrecision(18, 6);

        _ = builder
            .HasOne(bg => bg.Brand)
            .WithMany(b => b.Games)
            .HasForeignKey(bg => bg.BrandId)
            .HasConstraintName("fk_brand_games_brands_brand_id");

        _ = builder
            .HasOne(bg => bg.Game)
            .WithMany(g => g.Brands)
            .HasForeignKey(bg => bg.GameId)
            .HasConstraintName("fk_brand_games_games_game_id");

        _ = builder.HasIndex(e => e.GameId)
            .HasDatabaseName("ix_brand_games_game_id");
    }
}
