using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AggregateExecutionTimeMap : IEntityTypeConfiguration<AggregateExecutionTime>
{
    void IEntityTypeConfiguration<AggregateExecutionTime>.Configure(EntityTypeBuilder<AggregateExecutionTime> builder)
    {
        _ = builder.ToTable("aggregate_execution_time", Consts.ReportSchema);

        _ = builder.HasKey(b => new { b.AggregateType, b.From, b.To })
            .HasName("pk_aggregate_execution_time_id");

        _ = builder.Property(c => c.AggregateType)
            .IsRequired();

        _ = builder.Property(b => b.From)
            .IsRequired();

        _ = builder.Property(b => b.To)
            .IsRequired();

        _ = builder.HasIndex(b => new
        {
            b.AggregateType,
            b.From,
            b.To
        })
            .HasDatabaseName("ix_aggregate_execution_time_multiple_keys");
    }
}
