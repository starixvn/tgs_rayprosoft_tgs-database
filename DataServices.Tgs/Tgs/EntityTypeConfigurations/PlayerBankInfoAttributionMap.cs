#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBankInfoAttributionMap : IEntityTypeConfiguration<PlayerBankInfoAttribution>
{
    public void Configure(EntityTypeBuilder<PlayerBankInfoAttribution> builder)
    {
        _ = builder.ToTable("player_bankinfo_attributions");

        _ = builder.HasKey(pba => new { pba.BrandId, pba.BankInfoHash });
        _ = builder.Property(pba => pba.PlayerCode)
            .IsRequired();

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(pba => pba.PlayerCode)
            .HasConstraintName("fk_players_player_code")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(pba => pba.BrandId)
            .HasConstraintName("fk_brands_brand_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
