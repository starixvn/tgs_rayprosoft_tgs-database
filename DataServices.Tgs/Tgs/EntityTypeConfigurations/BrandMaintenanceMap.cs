using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandMaintenanceMap : IEntityTypeConfiguration<BrandMaintenance>
{
    void IEntityTypeConfiguration<BrandMaintenance>.Configure(EntityTypeBuilder<BrandMaintenance> builder)
    {
        _ = builder.ToTable("brand_maintenance");

        _ = builder.HasKey(bm => bm.Id);

        _ = builder.HasOne(bm => bm.Brand)
           .WithOne()
           .HasForeignKey<BrandMaintenance>(bm => bm.BrandId)
           .HasConstraintName("fk_brand_maintenance_brands_brand_id");

        _ = builder.Property(bm => bm.Content)
            .HasMaxLength(2000);

        _ = builder.Property(bm => bm.BeginTime)
            .HasColumnType("time without time zone")
            .IsRequired();

        _ = builder.Property(bm => bm.EndTime)
            .HasColumnType("time without time zone")
            .IsRequired();
    }
}
