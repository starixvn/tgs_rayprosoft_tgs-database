using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandDomainMap : IEntityTypeConfiguration<BrandDomain>
{
    void IEntityTypeConfiguration<BrandDomain>.Configure(EntityTypeBuilder<BrandDomain> builder)
    {
        _ = builder.ToTable("brand_domains");

        _ = builder.HasKey(e => e.Id);

        _ = builder.Property(e => e.Url)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.HasOne(e => e.Brand)
            .WithMany(e => e.Domains)
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_brand_domains_brands_brand_id");
    }
}
