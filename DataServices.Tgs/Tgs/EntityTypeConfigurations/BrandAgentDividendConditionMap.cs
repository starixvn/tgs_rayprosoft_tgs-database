using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandAgentDividendConditionMap : IEntityTypeConfiguration<BrandAgentDividendCondition>
{
    void IEntityTypeConfiguration<BrandAgentDividendCondition>.Configure(
        EntityTypeBuilder<BrandAgentDividendCondition> builder)
    {
        _ = builder.ToTable("brand_agent_dividend_conditions");

        _ = builder.HasKey(b => new
        {
            b.Rank,
            b.BrandId
        })
            .HasName("pk_brand_agent_dividend_conditions_rank_brand_id");

        _ = builder.Property(b => b.NetProfit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.DividendPercentage)
            .HasPrecision(9, 6)
            .IsRequired();
    }
}
