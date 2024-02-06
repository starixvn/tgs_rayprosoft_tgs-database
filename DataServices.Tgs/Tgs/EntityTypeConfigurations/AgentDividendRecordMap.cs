using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
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

        _ = builder.Property(b => b.BrandId)
            .IsRequired();

        _ = builder.Property(b => b.AgentId)
            .IsRequired();

        _ = builder.Property(b => b.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.NegativeAgentDividendAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.AgentDividendAmount)
            .HasPrecision(18, 6)
            .IsRequired();
        
        _ = builder.Property(b => b.ActualAgentDividendAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.SentByUsername)
            .HasMaxLength(64)
            .IsRequired(false);

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.Property(e => e.SentOn)
            .IsRequired(false);

        _ = builder.HasIndex(b => b.AgentDividendId)
            .IsUnique()
            .HasDatabaseName("ux_agent_dividend_records");

        _ = builder.HasIndex(b => new
            {
                b.BrandId,
                b.AgentId
            })
            .HasDatabaseName("ix_agent_dividend_records_brand_id_agent_id");
    }
}
