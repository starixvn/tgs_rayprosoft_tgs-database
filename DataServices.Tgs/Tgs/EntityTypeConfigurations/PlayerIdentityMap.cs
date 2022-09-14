using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerIdentityMap : IEntityTypeConfiguration<PlayerIdentity>
{
    void IEntityTypeConfiguration<PlayerIdentity>.Configure(EntityTypeBuilder<PlayerIdentity> builder)
    {
        _ = builder.ToTable("player_identity");

        _ = builder.HasKey(pi => pi.PlayerCode)
            .HasName("pk_player_identity");

        _ = builder.Property(pi => pi.PlayerAuthenticationFormId)
            .IsRequired();

        _ = builder.HasOne<Player>()
            .WithOne()
            .HasForeignKey<PlayerIdentity>(pi => pi.PlayerCode)
            .HasConstraintName("fk_player_identity_players_player_code")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
