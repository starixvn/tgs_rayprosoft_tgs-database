using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameProviderConfigurationMap : IEntityTypeConfiguration<GameProviderConfiguration>
{
    void IEntityTypeConfiguration<GameProviderConfiguration>.Configure(
        EntityTypeBuilder<GameProviderConfiguration> builder)
    {
        _ = builder.ToTable("game_provider_configurations");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_game_provider_configurations");

        _ = builder.Property(p => p.Name)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(256);

        _ = builder.Property(c => c.ClientId)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(c => c.SecretKey)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.GameProviderId)
            .IsRequired();

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.DesktopEndpoint)
            .HasMaxLength(1024)
            .IsRequired();

        _ = builder.Property(c => c.MobileEndpoint)
            .HasMaxLength(1024)
            .IsRequired();

        _ = builder.Property(c => c.ConfigurationData)
            .IsRequired();

        _ = builder.Property(c => c.IsDefault)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder.HasOne(p => p.GameProvider)
            .WithMany(p => p.GameProviderConfigurations)
            .HasForeignKey(p => p.GameProviderId)
            .HasConstraintName("fk_game_provider_configurations_game_providers_game_provider_id");

        _ = builder.HasIndex(e => e.GameProviderId)
            .HasDatabaseName("ix_game_provider_configurations_game_provider_id");
    }
}
