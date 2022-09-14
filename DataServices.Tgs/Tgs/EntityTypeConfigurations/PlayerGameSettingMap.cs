using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerGameSettingMap : IEntityTypeConfiguration<PlayerGameSetting>
{
    public void Configure(EntityTypeBuilder<PlayerGameSetting> builder)
    {
        _ = builder.ToTable("player_game_settings");

        _ = builder.HasKey(pgs => pgs.PlayerCode)
            .HasName("pk_player_game_settings");

        _ = builder.Property(pgs => pgs.IsAutoTransferToGame)
            .IsRequired()
            .HasDefaultValue(false);

        _ = builder.HasOne(pgs => pgs.Player)
            .WithOne(p => p.GameSetting)
            .HasForeignKey<PlayerGameSetting>(pgs => pgs.PlayerCode)
            .HasConstraintName("fk_player_game_settings_players");
    }
}
