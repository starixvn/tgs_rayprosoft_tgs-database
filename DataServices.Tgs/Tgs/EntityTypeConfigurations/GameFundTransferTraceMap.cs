using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameFundTransferTraceMap : IEntityTypeConfiguration<GameFundTransferTrace>
{
    void IEntityTypeConfiguration<GameFundTransferTrace>.Configure(EntityTypeBuilder<GameFundTransferTrace> builder)
    {
        _ = builder.ToTable("game_fund_transfer_trace");

        _ = builder
            .HasKey(e => new { e.GameProviderId, e.WalletId, e.PlayerCode })
            .HasName("pk_game_fund_transfer_trace");

        _ = builder
            .Property(e => e.GameProviderId)
            .HasColumnName("game_provider_id");

        _ = builder
            .Property(e => e.WalletId)
            .HasColumnName("wallet_id");

        _ = builder
            .Property(e => e.PlayerCode)
            .HasMaxLength(16)
            .HasColumnName("player_code");

        _ = builder
            .Property(e => e.CreatedOn)
            .HasColumnName("created_on");

        _ = builder
            .Property(e => e.UpdatedOn)
            .HasColumnName("updated_on");
    }
}
