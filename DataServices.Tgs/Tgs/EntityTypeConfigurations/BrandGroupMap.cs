using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGroupMap : BaseConfiguration, IEntityTypeConfiguration<BrandGroup>
{
    void IEntityTypeConfiguration<BrandGroup>.Configure(EntityTypeBuilder<BrandGroup> builder)
    {
        _ = builder.ToTable("brand_groups");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_brand_groups");

        _ = builder.Property(e => e.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.Name)
            .HasMaxLength(255)
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

        _ = builder.HasOne(e => e.Brand)
            .WithMany(e => e.BrandGroups)
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_brand_groups_brands_brand_id");

        _ = builder.HasIndex(e => e.BrandId)
            .HasDatabaseName("ix_brand_groups_brand_id");
    }
}
