using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentBankMap : IEntityTypeConfiguration<AgentBank>
{
    void IEntityTypeConfiguration<AgentBank>.Configure(EntityTypeBuilder<AgentBank> builder)
    {
        _ = builder.ToTable("agent_banks");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_agent_banks");

        _ = builder.Property(c => c.RealName)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.BankName)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.BankAccount)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.HasOne(c => c.Agent)
            .WithMany(c => c.Banks)
            .HasForeignKey(c => c.AgentId)
            .HasConstraintName("fk_agent_banks_agents_agent_id");

        _ = builder.HasIndex(c => c.AgentId)
            .HasDatabaseName("ix_agent_bankers_agent_id");
    }
}
