using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerFavoriteGameMap : IEntityTypeConfiguration<PlayerFavoriteGame>
{
    public void Configure(EntityTypeBuilder<PlayerFavoriteGame> builder)
    {
        _ = builder.ToTable("player_favorite_games");

        _ = builder.HasKey(fg => new { fg.PlayerCode, fg.GameId })
            .HasName("pk_player_favorite_games");

        _ = builder.Property(fg => fg.BrandId)
            .IsRequired();

        _ = builder.Property(fg => fg.GameId)
            .IsRequired();

        _ = builder.Property(fg => fg.GameType)
            .IsRequired();

        _ = builder.Property(fg => fg.SubGameProviderCode)
            .IsRequired()
            .HasMaxLength(16);

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(fg => fg.BrandId)
            .HasConstraintName("fk_player_favorite_games_brand_brand_id")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(fg => fg.PlayerCode)
            .HasConstraintName("fk_player_favorite_games_player_player_code")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
