using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandProductFeeMap : IEntityTypeConfiguration<BrandProductFee>
{
    void IEntityTypeConfiguration<BrandProductFee>.Configure(EntityTypeBuilder<BrandProductFee> builder)
    {
        _ = builder.ToTable("brand_product_fees");

        _ = builder.HasKey(b => b.BrandId)
            .HasName("pk_brand_product_fees");

        _ = builder.Property(c => c.LiveDealerPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGamePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();
    }
}
