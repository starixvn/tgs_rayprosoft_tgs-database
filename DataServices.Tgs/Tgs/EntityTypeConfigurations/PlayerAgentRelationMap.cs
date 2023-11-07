using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerAgentRelationMap : IEntityTypeConfiguration<PlayerAgentRelation>
{
    void IEntityTypeConfiguration<PlayerAgentRelation>.Configure(EntityTypeBuilder<PlayerAgentRelation> builder)
    {
        _ = builder.ToTable("player_agent_relations");

        _ = builder.HasKey(bc => new { bc.BrandId, bc.PlayerCode, bc.AgentId })
            .HasName("pk_brand_id_player_code_agent_id");

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.AgentId)
            .IsRequired();

        _ = builder.HasOne(p => p.Brand)
            .WithOne()
            .HasForeignKey<PlayerAgentRelation>(p => p.BrandId)
            .HasConstraintName("fk_player_agents_brands_brand_id");

        _ = builder.HasOne(p => p.Player)
            .WithOne()
            .HasForeignKey<PlayerAgentRelation>(p => p.PlayerCode)
            .HasConstraintName("fk_player_agents_players_player_code");

        _ = builder.HasOne(p => p.Agent)
            .WithOne()
            .HasForeignKey<PlayerAgentRelation>(p => p.AgentId)
            .HasConstraintName("fk_player_agents_agents_agent_id");
    }
}
