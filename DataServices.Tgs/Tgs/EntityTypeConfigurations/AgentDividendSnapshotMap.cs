using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendSnapshotMap : IEntityTypeConfiguration<AgentDividendSnapshot>
{
    void IEntityTypeConfiguration<AgentDividendSnapshot>.Configure(EntityTypeBuilder<AgentDividendSnapshot> builder)
    {
        _ = builder.ToTable("agent_dividend_snapshots");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agent_dividend_snapshots_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(b => b.Data)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();
    }
}
