using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameProviderFundTransferTransactionsMap : IEntityTypeConfiguration<GameProviderFundTransferTransaction>
{
    void IEntityTypeConfiguration<GameProviderFundTransferTransaction>.Configure(EntityTypeBuilder<GameProviderFundTransferTransaction> builder)
    {
        _ = builder.ToTable("game_provider_fund_transfer_transactions");

        _ = builder.HasKey(e => e.GameProviderFundTransferTransactionId)
            .HasName("pk_game_provider_fund_transfer_transaction_id");

        _ = builder.Property(c => c.TransactionId);

        _ = builder.Property(c => c.GameProviderId)
            .IsRequired();

        _ = builder.Property(c => c.WalletId)
            .IsRequired();

        _ = builder.Property(c => c.GameProviderTransactionId);

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired();

        _ = builder.Property(c => c.FundSource)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.FromWallet)
            .IsRequired();

        _ = builder.Property(c => c.ToWallet)
            .IsRequired();

        _ = builder.Property(e => e.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Amount)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.Balance)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(256);

        _ = builder.HasIndex(e => e.TransactionId)
          .HasDatabaseName("ix_game_provider_fund_transfer_transactions_transaction_id");

        _ = builder.HasIndex(e => e.WalletId)
            .HasDatabaseName("ix_game_provider_fund_transfer_transactions_wallet_id");

        _ = builder.HasIndex(e => e.PlayerCode)
            .HasDatabaseName("ix_game_provider_fund_transfer_transactions_player_code");
    }
}
