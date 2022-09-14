using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGameProviderScheduledMap :
    IEntityTypeConfiguration<BrandGameProviderSchedule>
{
    void IEntityTypeConfiguration<BrandGameProviderSchedule>.Configure(
        EntityTypeBuilder<BrandGameProviderSchedule> builder)
    {
        _ = builder.ToTable("brand_game_provider_schedules");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_brand_game_provider_schedule");

        _ = builder.Property(e => e.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.HasOne(e => e.BrandGameProvider)
            .WithMany(e => e.Schedules)
            .HasForeignKey(e => e.BrandGameProviderId)
            .HasConstraintName("fk_brand_game_provider_schedule_brand_game_providers_id");

        _ = builder.HasIndex(e => e.BrandGameProviderId)
            .HasDatabaseName("ix_brand_game_provider_schedule_brand_game_provider_id");
    }
}
