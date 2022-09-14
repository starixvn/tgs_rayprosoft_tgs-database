using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GamePlayerTransformIdnLiveMap : BaseConfiguration, IEntityTypeConfiguration<GamePlayerTransformIdnLive>
{
    void IEntityTypeConfiguration<GamePlayerTransformIdnLive>.Configure(EntityTypeBuilder<GamePlayerTransformIdnLive> builder)
    {
        _ = builder.ToTable("game_player_transform_idnlive");

        _ = builder.HasIndex(e => e.PlayerCode, "ix_game_player_transform_idnlive_player_code")
            .IsUnique();

        _ = builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasIdentityOptions(10000001L, null, null, null, null, null);

        _ = builder.Property(e => e.Configuration)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasColumnName("configuration");

        _ = builder.Property(e => e.CreatedOn)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("created_on");

        _ = builder.Property(e => e.PlayerCode)
            .IsRequired()
            .HasColumnType("character varying")
            .HasColumnName("player_code");

        _ = builder.Property(e => e.UpdatedOn)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("updated_on");

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(b => b.PlayerCode)
            .HasConstraintName("fk_game_player_transform_idnlive_players_player_code")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
