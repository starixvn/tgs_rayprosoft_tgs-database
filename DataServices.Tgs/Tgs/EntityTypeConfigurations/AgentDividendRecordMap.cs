using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendRecordMap : IEntityTypeConfiguration<AgentDividendRecord>
{
    void IEntityTypeConfiguration<AgentDividendRecord>.Configure(EntityTypeBuilder<AgentDividendRecord> builder)
    {
        _ = builder.ToTable("agent_dividend_records");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agent_dividend_records_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(b => b.NegativeDividendIds)
            .HasColumnType("text[]")
            .IsRequired();

        _ = builder.Property(b => b.AgentDividendAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.Property(e => e.SentOn)
            .IsRequired(false);
    }
}
