using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentProductFeeMap : IEntityTypeConfiguration<AgentProductFee>
{
    void IEntityTypeConfiguration<AgentProductFee>.Configure(EntityTypeBuilder<AgentProductFee> builder)
    {
        _ = builder.ToTable("agent_product_fees");

        _ = builder.HasKey(b => b.AgentId)
            .HasName("pk_agent_product_fees");

        _ = builder.Property(b => b.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.PreviousLiveDealerPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.PreviousSlotPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.PreviousLotteryPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.PreviousCardGamePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.PreviousSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.PreviousVirtualSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CurrentLiveDealerPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CurrentSlotPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CurrentLotteryPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CurrentCardGamePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CurrentSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CurrentVirtualSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.NextLiveDealerPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.NextSlotPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.NextLotteryPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.NextCardGamePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.NextSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.NextVirtualSportsPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();
    }
}
