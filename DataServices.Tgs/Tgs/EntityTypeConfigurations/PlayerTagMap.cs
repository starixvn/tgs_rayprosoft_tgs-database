using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerTagMap : IEntityTypeConfiguration<PlayerTags>
{
    void IEntityTypeConfiguration<PlayerTags>.Configure(EntityTypeBuilder<PlayerTags> builder)
    {
        _ = builder.ToTable("player_tags");

        _ = builder.HasKey(bc => bc.PlayerCode)
            .HasName("pk_tag_player_code");

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.Tag)
            .IsRequired();

        builder.HasIndex(c => new
            {
                c.PlayerCode,
                c.Tag
            })
            .IsUnique();
    }
}
