using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerSportsBetLimitMap : IEntityTypeConfiguration<PlayerSportsBetLimit>
{
    void IEntityTypeConfiguration<PlayerSportsBetLimit>.Configure(EntityTypeBuilder<PlayerSportsBetLimit> builder)
    {
        _ = builder.ToTable("player_sports_bet_limits");

        _ = builder.HasKey(e => new { e.PlayerCode, e.SportMarketTypeId })
            .HasName("pk_player_sports_bet_limits");

        _ = builder.Property(e => e.MinBet)
            .IsRequired();

        _ = builder.Property(e => e.MaxBet)
            .IsRequired();

        _ = builder.Property(e => e.MaxBetPerMatch)
            .IsRequired();

        _ = builder.HasOne(e => e.Player)
            .WithMany(e => e.SportsBetLimits)
            .HasForeignKey(e => e.PlayerCode)
            .HasConstraintName("fk_player_sports_bet_limits_players_player_code")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasOne(e => e.SportMarketType)
            .WithMany(e => e.PlayerSportsBetLimits)
            .HasForeignKey(e => e.SportMarketTypeId)
            .HasConstraintName("fk_player_sports_bet_limits_sport_market_types_sport_market_type_id")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(e => e.SportMarketTypeId)
            .HasDatabaseName("ix_player_sports_bet_limits_sport_market_id");
    }
}
