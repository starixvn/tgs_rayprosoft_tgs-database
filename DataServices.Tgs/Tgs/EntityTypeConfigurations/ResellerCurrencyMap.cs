using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class ResellerCurrencyMap : IEntityTypeConfiguration<ResellerCurrency>
{
    void IEntityTypeConfiguration<ResellerCurrency>.Configure(EntityTypeBuilder<ResellerCurrency> builder)
    {
        _ = builder.ToTable("reseller_currencies");

        _ = builder.HasKey(e => new { e.ResellerId, e.CurrencyCode })
            .HasName("pk_reseller_currencies");

        _ = builder
            .HasOne(e => e.Reseller)
            .WithMany(e => e.Currencies)
            .HasForeignKey(e => e.ResellerId)
            .HasConstraintName("fk_reseller_currencies_resellers_reseller_id");

        _ = builder
            .HasOne(e => e.Currency)
            .WithMany(e => e.ResellerCurrencies)
            .HasForeignKey(e => e.CurrencyCode)
            .HasConstraintName("fk_reseller_currencies_currencies_currency_code");

        _ = builder.HasIndex(e => e.CurrencyCode)
            .HasDatabaseName("ix_reseller_currencies_currency_code");
    }
}
