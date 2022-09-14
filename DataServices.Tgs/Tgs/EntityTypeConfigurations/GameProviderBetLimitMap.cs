using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameProviderBetLimitMap : IEntityTypeConfiguration<GameProviderBetLimit>
{
    void IEntityTypeConfiguration<GameProviderBetLimit>.Configure(EntityTypeBuilder<GameProviderBetLimit> builder)
    {
        _ = builder.ToTable("game_provider_bet_limits");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_game_provider_bet_limits");

        _ = builder.Property(e => e.CurrencyCode)
            .HasMaxLength(16);

        _ = builder.Property(e => e.MinBet)
            .IsRequired();

        _ = builder.Property(e => e.MaxBet)
            .IsRequired();

        _ = builder.Property(e => e.MaxBetPerMatch);

        _ = builder.Property(e => e.ExternalSetting)
            .HasMaxLength(255)
            .IsRequired();

        _ = builder.HasOne(e => e.Currency)
            .WithMany(e => e.GameProviderBetLimits)
            .HasForeignKey(e => e.CurrencyCode)
            .HasConstraintName("fk_game_provider_bet_limits_currencies_currency_code");

        _ = builder.HasIndex(e => e.CurrencyCode)
            .HasDatabaseName("ix_game_provider_bet_limits_currency_code");

        _ = builder.HasOne(e => e.GameProvider)
            .WithMany(e => e.BetLimits)
            .HasForeignKey(e => e.GameProviderId)
            .HasConstraintName("fk_game_provider_bet_limits_game_providers_game_provider_id");

        _ = builder.HasIndex(e => e.GameProviderId)
            .HasDatabaseName("ix_game_provider_bet_limits_game_provider_id");
    }
}
