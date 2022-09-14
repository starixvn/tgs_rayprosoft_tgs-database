using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandCurrencyMap : IEntityTypeConfiguration<BrandCurrency>
{
    void IEntityTypeConfiguration<BrandCurrency>.Configure(EntityTypeBuilder<BrandCurrency> builder)
    {
        _ = builder.ToTable("brand_currencies");

        _ = builder.HasKey(e => new { e.BrandId, e.CurrencyCode });

        _ = builder.Property(e => e.CurrencyCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(e => e.BrandCurrencyCode)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.HasOne(e => e.Brand)
            .WithMany(e => e.Currencies)
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_brand_currencies_brands_brand_id");

        _ = builder.HasOne(e => e.Currency)
            .WithMany(e => e.BrandCurrencies)
            .HasForeignKey(e => e.CurrencyCode)
            .HasConstraintName("fk_brand_currencies_currencies_currency_code");

        _ = builder.HasIndex(e => e.CurrencyCode)
            .HasDatabaseName("ix_brand_currencies_currency_code");
    }
}
