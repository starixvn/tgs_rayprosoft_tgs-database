using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentTransactionMap : IEntityTypeConfiguration<AgentTransaction>
{
    void IEntityTypeConfiguration<AgentTransaction>.Configure(EntityTypeBuilder<AgentTransaction> builder)
    {
        _ = builder.ToTable("agent_transactions");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_agent_transactions");

        _ = builder.Property(e => e.Amount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(e => e.Balance)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LockAmount)
            .HasPrecision(18, 6)
            .HasDefaultValue(0);

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

        _ = builder.HasIndex(e => e.AgentId)
            .HasDatabaseName("ix_agent_transactions_agent_id");

        _ = builder.HasOne(e => e.Wallet)
            .WithMany()
            .HasForeignKey(e => e.WalletId)
            .HasConstraintName("fk_agent_transaction_wallet_id");

        _ = builder.HasIndex(e => e.WalletId)
            .HasDatabaseName("ix_agent_transactions_wallet_id");

        _ = builder
            .HasOne(e => e.Brand)
            .WithMany()
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_agent_transactions_brands_brand_id");

        _ = builder.HasIndex(e => e.BrandId)
            .HasDatabaseName("ix_agent_transactions_brand_id");
    }
}
