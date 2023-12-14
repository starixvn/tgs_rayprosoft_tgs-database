using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendMultipleLayerMap : IEntityTypeConfiguration<AgentDividendMultipleLayer>
{
    void IEntityTypeConfiguration<AgentDividendMultipleLayer>.Configure(
        EntityTypeBuilder<AgentDividendMultipleLayer> builder)
    {
        _ = builder.ToTable("agent_dividend_multiple_layers");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agent_dividend_multiple_layers_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(b => b.AgentDividendPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.ActualDividendPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.AgentCoveredBonus)
            .HasPrecision(18, 6)
            .IsRequired(false);

        _ = builder.Property(b => b.AgentCoveredBonusAdjust)
            .HasPrecision(18, 6)
            .IsRequired(false);

        _ = builder.Property(b => b.Dividend)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.AgentId)
            .IsRequired();

        _ = builder.Property(b => b.DividendProviderAgentId)
            .IsRequired();

        _ = builder.Property(b => b.DividendProviderId)
            .IsRequired();

        _ = builder.Property(b => b.Layer)
            .IsRequired();

        _ = builder.Property(b => b.ContractId)
            .HasDefaultValue(Guid.Empty)
            .IsRequired();

        _ = builder.HasIndex(b => new
        {
            b.AgentId,
            b.DividendProviderAgentId
        })
            .HasDatabaseName("ix_agent_dividend_multiple_layers_agent_id_dividend_provider_agent_id");
    }
}
