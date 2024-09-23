using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class SubGameProviderMap : IEntityTypeConfiguration<SubGameProvider>
{
    void IEntityTypeConfiguration<SubGameProvider>.Configure(EntityTypeBuilder<SubGameProvider> builder)
    {
        _ = builder.ToTable("sub_game_providers");

        _ = builder.HasKey(c => c.Code)
            .HasName("pk_sub_game_providers");

        _ = builder.Property(c => c.Code)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired();

        _ = builder.Property(e => e.Description)
            .HasMaxLength(128);

        _ = builder.Property(e => e.GameProviderId)
            .IsRequired();

        _ = builder.Property(e => e.Localization)
            .HasColumnType(ColumnTypes.Jsonb);

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

        _ = builder.HasOne(c => c.GameProvider)
            .WithMany(c => c.SubGameProviders)
            .HasForeignKey(c => c.GameProviderId)
            .HasConstraintName("fk_sub_game_providers_game_providers_game_provider_id");

        _ = builder.HasIndex(e => e.GameProviderId)
            .HasDatabaseName("ix_sub_game_providers_game_provider_id");
    }
}
