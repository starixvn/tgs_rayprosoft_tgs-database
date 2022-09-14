using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBankInfoTagMap : IEntityTypeConfiguration<PlayerBankInfoTag>
{
    public void Configure(EntityTypeBuilder<PlayerBankInfoTag> builder)
    {
        _ = builder.ToTable("player_bank_info_tags");

        _ = builder.HasKey(bt => new { bt.BrandId, bt.BankInfoId, bt.TagType });

        _ = builder.Property(bt => bt.PlayerCode)
            .IsRequired();
        _ = builder.Property(bt => bt.Tag)
            .IsRequired();

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(bt => bt.PlayerCode)
            .HasConstraintName("fk_player_bank_info_tags_players_player_code")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<PlayerBankInfo>()
            .WithMany()
            .HasForeignKey(bt => bt.BankInfoId)
            .HasConstraintName("fk_player_bank_info_tags_player_bank_infos_bank_info_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
