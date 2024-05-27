using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendProductFeeMap : IEntityTypeConfiguration<AgentDividendProductFee>
{
    void IEntityTypeConfiguration<AgentDividendProductFee>.Configure(EntityTypeBuilder<AgentDividendProductFee> builder)
    {
        _ = builder.ToTable("agent_dividend_product_fees");

        _ = builder.HasKey(b => b.AgentDividendId)
            .HasName("pk_agent_dividend_product_fees_id");

        _ = builder.Property(b => b.BrandId)
            .IsRequired();

        _ = builder.Property(b => b.AgentDividendId)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGamePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameWinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerWinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryWinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotWinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsWinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsWinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();


        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => b.AgentDividendId)
            .HasDatabaseName("ix_agent_dividend_product_fees_agent_dividend_id");
    }
}
