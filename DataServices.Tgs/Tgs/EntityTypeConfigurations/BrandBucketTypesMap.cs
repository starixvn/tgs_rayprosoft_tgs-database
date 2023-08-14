#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandBucketTypesMap : IEntityTypeConfiguration<BrandBucketTypes>
{
    public void Configure(EntityTypeBuilder<BrandBucketTypes> builder)
    {
        _ = builder.ToTable("brand_bucket_types");

        _ = builder.HasKey(bt => bt.BrandId)
            .HasName("pk_brand_bucket_types");

        _ = builder.Property(bt => bt.BucketTypes)
            .IsRequired()
            .HasColumnType("jsonb");

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(bt => bt.BrandId)
            .HasConstraintName("fk_brands");
    }
}
