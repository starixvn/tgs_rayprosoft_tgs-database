using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class RoundMap : IEntityTypeConfiguration<Round>
{
    void IEntityTypeConfiguration<Round>.Configure(EntityTypeBuilder<Round> builder)
    {
        _ = builder.ToTable("rounds", Consts.BetSchema);

        _ = builder.HasKey(bc => bc.Id)
            .HasName("pk_rounds");

        _ = builder.Property(c => c.ExternalRoundId)
            .HasMaxLength(255)
            .IsRequired();

        _ = builder.Property(c => c.GameProviderId)
            .IsRequired();

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired();

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.GameId)
            .IsRequired();

        _ = builder.Property(c => c.CurrencyCode)
            .HasMaxLength(10)
            .IsRequired();

        _ = builder.Property(c => c.GameProviderConfigurationId)
            .IsRequired();

        _ = builder.Property(c => c.WalletId)
            .IsRequired();

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.ClosedOn);

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder.Property(c => c.ExternalCreatedOn);

        _ = builder.Property(c => c.ExternalClosedOn);

        _ = builder.Property(c => c.BetAmount)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.ValidBetAmount)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.WinLoss)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.TieBetAdjustment)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.Commission)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.EffectiveBettingPercentage)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.ClientStatus)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.HasIndex(c => c.GameProviderId)
            .HasDatabaseName("ix_rounds_game_provider_id");

        _ = builder.HasIndex(c => c.PlayerCode)
            .HasDatabaseName("ix_rounds_player_code");

        _ = builder.HasIndex(c => c.GameId)
            .HasDatabaseName("ix_rounds_game_id");

        _ = builder.HasIndex(c => c.BrandId)
            .HasDatabaseName("ix_rounds_brand_id");

        _ = builder.HasIndex(c => c.ClosedOn)
            .HasMethod("brin")
            .HasDatabaseName("ix_rounds_closed_on");

        _ = builder.HasIndex(c => new { c.ExternalRoundId, c.GameProviderId, c.GameId, c.WalletId })
            .HasDatabaseName("ix_rounds_wallet_id_composite");

        _ = builder.HasIndex(c => new { c.GameProviderConfigurationId, c.WalletId, c.GameId, c.ExternalRoundId })
            .HasDatabaseName("ix_rounds_game_provider_configuration_id_composite");
    }
}
