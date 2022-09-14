using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlatformCreditMap : BaseConfiguration, IEntityTypeConfiguration<PlatformCredit>
{
    void IEntityTypeConfiguration<PlatformCredit>.Configure(EntityTypeBuilder<PlatformCredit> builder)
    {
        _ = builder.ToTable("platform_credits");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_platform_credits");

        _ = builder.Property(e => e.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.Credit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Balance)
            .HasPrecision(18, 6)
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
            .WithOne()
            .HasForeignKey<PlatformCredit>(e => e.BrandId)
            .HasConstraintName("fk_platform_credits_brands_brand_id")
            .IsRequired();

        _ = builder.HasIndex(e => e.BrandId)
            .HasDatabaseName("ix_platform_credits_brand_id");
    }
}
