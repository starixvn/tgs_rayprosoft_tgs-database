using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendContractValidNumberMap : IEntityTypeConfiguration<AgentDividendContractValidNumber>
{
    void IEntityTypeConfiguration<AgentDividendContractValidNumber>.Configure(
        EntityTypeBuilder<AgentDividendContractValidNumber> builder)
    {
        _ = builder.ToTable("agent_dividend_contract_valid_numbers");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agent_dividend_contract_valid_numbers_id");

        _ = builder.Property(c => c.ValidBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.DepositAmount)
            .HasPrecision(18, 6)
            .IsRequired();


        _ = builder.HasOne(b => b.AgentDividendContract)
            .WithOne(b => b.ValidNumberDefinition)
            .HasForeignKey<AgentDividendContractValidNumber>(e => e.AgentDividendContractId)
            .IsRequired();
    }
}
