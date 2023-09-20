using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.Infrastructures.Extensions;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandPaymentSettingsMap : IEntityTypeConfiguration<BrandPaymentSettings>
{
    public void Configure(EntityTypeBuilder<BrandPaymentSettings> builder)
    {
        _ = builder.ToTable("brand_payment_settings");

        _ = builder.HasKey(bps => bps.BrandId);

        _ = builder.Property(bps => bps.PlayerBankInfoCountLimit);

        _ = builder.HasOne<Brand>()
            .WithOne()
            .HasConstraintName("fk_brands")
            .HasForeignKey<BrandPaymentSettings>(bps => bps.BrandId);
    }
}
