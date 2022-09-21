using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerAggregateMap : IEntityTypeConfiguration<PlayerAggregate>
{
    void IEntityTypeConfiguration<PlayerAggregate>.Configure(EntityTypeBuilder<PlayerAggregate> builder)
    {
        _ = builder.ToTable("player_aggregates", Consts.ReportSchema);

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_aggregates_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(b => b.RegisteredCount)
            .IsRequired();

        _ = builder.Property(b => b.FirstFundInCount)
            .IsRequired();

        _ = builder.Property(b => b.DepositAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.WithdrawalAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.CompanyAdjustAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.AgentAdjustAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.SystemAdjustAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.BonusAdjustAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.BonusAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.RebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.DividendAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.PromotionAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.BetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.ValidBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.OriginalTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.Turnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.WinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.AllAgentRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.DepositHandlingFee)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.WithdrawHandlingFee)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.NoIncludeNetProfitCompanyAdjustAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.NoIncludeNetProfitAgentAdjustAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.NoIncludeNetProfitBonusAdjustAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.AgentDividendPercentage)
            .HasPrecision(18, 6);

        _ = builder.Property(b => b.ChiefAgentDividendPercentage)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.AgentDividendPercentageTreeData)
            .HasColumnType("jsonb")
            .IsRequired(false);

        _ = builder.Property(b => b.ReportDate)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => new
        {
            b.ReportDate,
            b.BrandId,
            b.AgentId,
            b.PlayerCode
        })
            .HasDatabaseName("ix_player_aggregates_multiple_keys");

        _ = builder.HasIndex(b => new { b.AgentId })
            .HasDatabaseName("ix_player_aggregates_agent_id");
    }
}
