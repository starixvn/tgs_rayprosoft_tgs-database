using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    void IEntityTypeConfiguration<Transaction>.Configure(EntityTypeBuilder<Transaction> builder)
    {
        _ = builder.ToTable("transactions");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_transactions");

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired();

        _ = builder.Property(c => c.Amount)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.LockAmount)
            .HasPrecision(18, 6)
            .HasDefaultValue(0);

        _ = builder.Property(c => c.Balance)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.LockedBalance)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0M);

        _ = builder.Property(c => c.Type)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(e => e.RecordedOn)
            .IsRequired();

        _ = builder.Property(e => e.SentOn)
            .IsRequired(false);

        _ = builder.HasIndex(e => e.PlayerCode)
            .HasDatabaseName("ix_transactions_player_code");

        _ = builder
            .HasOne(e => e.Brand)
            .WithMany()
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_transactions_brands_brand_id");

        _ = builder.HasIndex(e => e.BrandId)
            .HasDatabaseName("ix_transactions_brand_id");

        _ = builder
            .HasOne(e => e.Wallet)
            .WithMany()
            .HasForeignKey(e => e.WalletId)
            .HasConstraintName("fk_transactions_wallets_wallet_id");

        _ = builder.HasIndex(e => e.WalletId)
            .HasDatabaseName("ix_transactions_wallet_id");
    }
}
