using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AdjustAgentRecordMap : IEntityTypeConfiguration<AdjustAgentRecord>
{
    void IEntityTypeConfiguration<AdjustAgentRecord>.Configure(EntityTypeBuilder<AdjustAgentRecord> builder)
    {
        _ = builder.ToTable("adjust_agent_records");

        _ = builder.HasKey(bc => bc.Id)
            .HasName("pk_adjust_agent_records_id");

        _ = builder.Property(c => c.TransactionId);

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.AgentId)
            .IsRequired();

        _ = builder.Property(c => c.AdjustmentType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Type)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.TransferType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(p => p.TransferTarget);

        _ = builder.Property(c => c.Amount)
            .HasPrecision(18, 6);

        _ = builder.Property(p => p.Remark);

        _ = builder.Property(l => l.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(l => l.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(c => new
        {
            c.CreatedOn,
            c.BrandId,
            c.AgentId,
            c.Type
        })
            .HasDatabaseName("ix_adjust_agent_record_multiple_keys");
    }
}
