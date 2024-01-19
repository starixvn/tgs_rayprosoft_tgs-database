using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerTagMap : IEntityTypeConfiguration<PlayerTag>
{
    void IEntityTypeConfiguration<PlayerTag>.Configure(EntityTypeBuilder<PlayerTag> builder)
    {
        _ = builder.ToTable("player_tags");

        _ = builder.HasKey(bc => new
        {
            bc.Tag,
            bc.PlayerCode
        })
            .HasName("pk_tag_player_code_tag");

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.Tag)
            .IsRequired();
    }
}
