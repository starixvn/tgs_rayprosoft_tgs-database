using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendContractMap : IEntityTypeConfiguration<AgentDividendContract>
{
    void IEntityTypeConfiguration<AgentDividendContract>.Configure(
        EntityTypeBuilder<AgentDividendContract> builder)
    {
        _ = builder.ToTable("agent_dividend_contracts");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agent_dividend_contracts_id");

        _ = builder.Property(b => b.ContractDividendType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.ContractStatus)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.HasOne(b => b.Agent)
            .WithOne()
            .HasForeignKey<AgentDividendContract>(e => e.AgentId)
            .IsRequired();

        _ = builder.HasMany(b => b.AgentDividendContractPercentages)
            .WithOne(b => b.AgentDividendContract)
            .HasForeignKey(b => b.AgentDividendContractId)
            .IsRequired();

        _ = builder.HasOne(b => b.ValidNumberDefinition)
            .WithOne(b => b.AgentDividendContract)
            .HasForeignKey<AgentDividendContractValidNumber>(b => b.AgentDividendContractId)
            .IsRequired();
    }
}
