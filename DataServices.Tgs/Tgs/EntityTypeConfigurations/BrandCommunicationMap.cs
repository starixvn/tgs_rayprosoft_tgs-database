using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandCommunicationMap : IEntityTypeConfiguration<BrandCommunication>
{
    void IEntityTypeConfiguration<BrandCommunication>.Configure(EntityTypeBuilder<BrandCommunication> builder)
    {
        _ = builder.ToTable("brand_communications");

        _ = builder.HasKey(e => e.Id);

        _ = builder.HasOne(e => e.Brand)
            .WithMany()
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_brand_communications_brands_brand_id");

        _ = builder.Property(e => e.Type)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(e => e.Phone)
            .HasMaxLength(32);

        _ = builder.Property(e => e.AppId)
            .HasMaxLength(128);

        _ = builder.Property(e => e.QRCodeUrl)
            .HasMaxLength(1024);
    }
}
