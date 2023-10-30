using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentEventSourceMap : IEntityTypeConfiguration<AgentEventSource>
{
    public void Configure(EntityTypeBuilder<AgentEventSource> builder)
    {
        _ = builder.ToTable("agent_event_source");

        _ = builder.HasKey(p => p.Id);

        _ = builder.Property(p => p.BrandId)
            .IsRequired();

        _ = builder.Property(p => p.AgentId)
            .IsRequired();

        _ = builder.Property(p => p.Action)
            .IsRequired();

        _ = builder.Property(p => p.ChangeSets)
            .HasColumnType("jsonb")
            .IsRequired();

        _ = builder.Property(p => p.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();

        _ = builder.Property(p => p.ModifyUser);
    }
}
