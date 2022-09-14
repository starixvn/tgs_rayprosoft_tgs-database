using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameMap : BaseConfiguration, IEntityTypeConfiguration<Game>
{
    void IEntityTypeConfiguration<Game>.Configure(EntityTypeBuilder<Game> builder)
    {
        _ = builder.ToTable("games");

        ConfigureBaseProperties<Game, int>(builder, "pk_games");

        _ = builder.Property(e => e.Id)
            .ValueGeneratedNever();

        _ = builder.Property(e => e.Code)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(e => e.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.ExternalId)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(e => e.Description)
            .HasMaxLength(128);

        _ = builder.Property(e => e.EndpointPath)
            .HasMaxLength(2048);

        _ = builder.Property(e => e.RuleUrl)
            .HasMaxLength(512);

        _ = builder.Property(e => e.Type)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(e => e.PlatformType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(e => e.SubGame)
            .IsRequired();

        _ = builder.Property(e => e.AvailableToBrand)
            .IsRequired();

        _ = builder.Property(e => e.HasTurnoverOnTieBet)
            .IsRequired();

        _ = builder.Property(e => e.Html5)
            .IsRequired();

        _ = builder.Property(e => e.AvailableCurrencies)
            .HasMaxLength(1024)
            .IsRequired()
            .HasDefaultValue(string.Empty);

        _ = builder.Property(e => e.Localization)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(e => e.SubGameProviderCode)
            .HasMaxLength(16);

        _ = builder.HasOne(e => e.GameProvider)
            .WithMany(e => e.Games)
            .HasForeignKey(e => e.GameProviderId)
            .HasConstraintName("fk_games_game_providers_game_provider_id");

        _ = builder.HasIndex(e => e.GameProviderId)
            .HasDatabaseName("ix_games_game_provider_id");

        _ = builder.HasOne(e => e.SubGameProvider)
            .WithMany(e => e.Games)
            .HasForeignKey(e => e.SubGameProviderCode)
            .HasConstraintName("fk_games_sub_game_providers_sub_game_provider_code");

        _ = builder.HasIndex(e => e.SubGameProviderCode)
            .HasDatabaseName("ix_games_sub_game_provider_code");
    }
}
