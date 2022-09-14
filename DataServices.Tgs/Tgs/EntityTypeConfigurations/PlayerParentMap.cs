using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerParentMap : IEntityTypeConfiguration<PlayerParent>
{
    void IEntityTypeConfiguration<PlayerParent>.Configure(EntityTypeBuilder<PlayerParent> builder)
    {
        _ = builder.ToTable("player_parents");

        _ = builder.HasKey(bc => bc.PlayerCode)
            .HasName("pk_player_parent_code");

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.ParentPlayerCode)
            .HasMaxLength(16)
            .IsRequired();
    }
}
