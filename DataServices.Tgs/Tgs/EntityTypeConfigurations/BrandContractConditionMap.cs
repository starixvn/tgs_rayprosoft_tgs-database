using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandContractConditionMap : IEntityTypeConfiguration<BrandContractCondition>
{
    void IEntityTypeConfiguration<BrandContractCondition>.Configure(
        EntityTypeBuilder<BrandContractCondition> builder)
    {
        _ = builder.ToTable("brand_contract_conditions");

        _ = builder.HasKey(b => new
        {
            b.Rank,
            b.BrandContractId
        })
            .HasName("pk_brand_contract_conditions_rank_brand_contract_id");

        _ = builder.Property(b => b.NetProfit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.WinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.DividendPercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(b => b.BrandContractId)
            .IsRequired();
    }
}
