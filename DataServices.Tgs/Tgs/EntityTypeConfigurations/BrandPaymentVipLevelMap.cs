using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandPaymentVipLevelMap : IEntityTypeConfiguration<BrandPaymentVipLevel>
{
    void IEntityTypeConfiguration<BrandPaymentVipLevel>.Configure(EntityTypeBuilder<BrandPaymentVipLevel> builder)
    {
        _ = builder.ToTable("brand_payment_vip_levels");

        _ = builder.HasKey(bc => new { bc.BrandPaymentId, bc.VipLevelId })
            .HasName("pk_brand_payment_vip_levels");

        _ = builder
            .HasOne(bc => bc.BrandPayment)
            .WithMany(c => c.VipLevels)
            .HasForeignKey(bc => bc.BrandPaymentId)
            .HasConstraintName("fk_brand_payment_vip_levels_brand_payments_brand_payment_id");

        _ = builder
            .HasOne(bc => bc.VipLevel)
            .WithMany(c => c.PaymentVipLevels)
            .HasForeignKey(bc => bc.VipLevelId)
            .HasConstraintName("fk_brand_payment_vip_levels_vip_levels_vip_level_id");

        _ = builder.HasIndex(e => e.VipLevelId)
            .HasDatabaseName("ix_brand_payment_vip_levels_vip_level_id");
    }
}
