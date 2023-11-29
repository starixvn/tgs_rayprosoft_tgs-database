using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendContractPercentageMap : IEntityTypeConfiguration<AgentDividendContractPercentage>
{
    void IEntityTypeConfiguration<AgentDividendContractPercentage>.Configure(
        EntityTypeBuilder<AgentDividendContractPercentage> builder)
    {
        _ = builder.ToTable("agent_dividend_contract_percentages");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agent_dividend_contract_percentages_id");

        _ = builder.Property(b => b.ContractGameType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Percentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.HasOne(b => b.AgentDividendContract)
            .WithMany(b => b.AgentDividendContractPercentages)
            .HasForeignKey(e => e.AgentDividendContractId)
            .IsRequired();
    }
}
