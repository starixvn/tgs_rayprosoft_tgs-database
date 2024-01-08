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

        _ = builder.Property(b => b.Name)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.GameTypes)
            .HasColumnType("text[]")
            .IsRequired();

        _ = builder.Property(b => b.ContractDividendType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.ContractStatus)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.GradeIntervalLimit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.ValidBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.DepositAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();
    }
}
