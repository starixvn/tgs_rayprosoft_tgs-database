using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentWalletMap : IEntityTypeConfiguration<AgentWallet>
{
    void IEntityTypeConfiguration<AgentWallet>.Configure(EntityTypeBuilder<AgentWallet> builder)
    {
        _ = builder.ToTable("agent_wallets");

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_agent_wallets");

        _ = builder.Property(e => e.CurrencyCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(e => e.Balance)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(e => e.CreatedOn)
            .IsRequired();

        _ = builder.Property(e => e.UpdatedOn)
            .IsRequired();

        _ = builder.HasOne(e => e.Agent)
            .WithMany(e => e.Wallets)
            .HasForeignKey(e => e.AgentId)
            .HasConstraintName("fk_agent_wallet_agent_id")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasOne(e => e.Currency)
            .WithMany()
            .HasForeignKey(e => e.CurrencyCode)
            .HasConstraintName("fk_agent_wallets_currencies_currency_code")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(e => e.CurrencyCode)
            .HasDatabaseName("ix_agent_wallets_currency_code");
    }
}
