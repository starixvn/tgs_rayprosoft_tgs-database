using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class WalletTypeMap : IEntityTypeConfiguration<Wallet>
{
    void IEntityTypeConfiguration<Wallet>.Configure(EntityTypeBuilder<Wallet> builder)
    {
        _ = builder.ToTable("wallets");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_wallets");

        _ = builder.Property(e => e.PlayerCode)
            .IsRequired();

        _ = builder.Property(e => e.CurrencyCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(e => e.ExternalCurrencyCode)
            .HasMaxLength(16);

        _ = builder.Property(e => e.Balance)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(e => e.LockedBalance)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0M);

        _ = builder.Property(e => e.CreatedOn)
            .IsRequired();

        _ = builder.Property(e => e.UpdatedOn)
            .IsRequired();

        _ = builder.Property(e => e.BrandId);
        _ = builder.Property(e => e.CashType)
            .IsRequired()
            .HasDefaultValue("Player");

        _ = builder.Property(e => e.SnapshotId);

        _ = builder.HasOne(e => e.Currency)
            .WithMany(e => e.Wallets)
            .HasForeignKey(e => e.CurrencyCode)
            .HasConstraintName("fk_wallets_currencies_currency_code")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(e => e.CurrencyCode)
            .HasDatabaseName("ix_wallets_currency_code");
    }
}
