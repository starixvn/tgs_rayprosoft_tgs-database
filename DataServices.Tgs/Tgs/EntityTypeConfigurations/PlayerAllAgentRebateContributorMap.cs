using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerAllAgentRebateContributorMap : IEntityTypeConfiguration<PlayerAllAgentRebateContributor>
{
    void IEntityTypeConfiguration<PlayerAllAgentRebateContributor>.Configure(
        EntityTypeBuilder<PlayerAllAgentRebateContributor> builder)
    {
        _ = builder.ToTable("player_all_agent_rebate_contributors");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_all_agent_rebates_contributor_id");

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.ChildPlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.SportsTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsWinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsWinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerWinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameWinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotWinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryWinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsTurnoverRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsTurnoverRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerTurnoverRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameTurnoverRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotTurnoverRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryTurnoverRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.SportsWinLossRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsWinLossRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerWinLossRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameWinLossRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotWinLossRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryWinLossRebate)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.SettleDate)
            .IsRequired();

        _ = builder.Property(b => b.From)
            .HasDefaultValueSql("now()")
            .IsRequired();

        _ = builder.Property(b => b.To)
            .HasDefaultValueSql("now()")
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => new
        {
            b.SettleDate,
            b.PlayerCode,
            b.ChildPlayerCode
        })
            .HasDatabaseName("ix_player_all_agent_rebate_contributors_settle_date_player_code");
    }
}
