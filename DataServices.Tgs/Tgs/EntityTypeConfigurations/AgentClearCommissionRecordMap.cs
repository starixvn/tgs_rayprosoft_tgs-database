using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentClearCommissionRecordMap : IEntityTypeConfiguration<AgentClearCommissionRecord>
{
    public void Configure(EntityTypeBuilder<AgentClearCommissionRecord> builder)
    {
        _ = builder.ToTable("agent_clear_commission_records");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_agent_clear_commission_records_id");

        _ = builder.Property(c => c.AgentDividendId)
            .IsRequired();

        _ = builder.Property(c => c.CommissionAmount)
            .HasDefaultValue(0M)
            .IsRequired();

        _ = builder.Property(c => c.ClearByUserId)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();
    }
}
