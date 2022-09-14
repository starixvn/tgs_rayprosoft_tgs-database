using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class StationLetterPlayerMap : IEntityTypeConfiguration<StationLetterPlayer>
{
    void IEntityTypeConfiguration<StationLetterPlayer>.Configure(EntityTypeBuilder<StationLetterPlayer> builder)
    {
        _ = builder.ToTable("station_letter_players");

        _ = builder.HasKey(c => new { c.StationLetterId, c.PlayerCode })
            .HasName("pk_station_letter_players");

        _ = builder.Property(c => c.IsRead)
            .IsRequired();

        _ = builder.Property(c => c.ReadOn);

        _ = builder.HasOne(p => p.StationLetter)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.StationLetterId)
            .HasConstraintName("fk_station_letter_players_station_letters_station_letter_id");

        _ = builder
            .HasOne(p => p.Player)
            .WithMany(p => p.Letters)
            .HasForeignKey(p => p.PlayerCode)
            .HasConstraintName("fk_station_letter_players_players_player_code");

        _ = builder.HasIndex(c => c.PlayerCode)
            .HasDatabaseName("ix_station_letter_players_player_code");
    }
}
