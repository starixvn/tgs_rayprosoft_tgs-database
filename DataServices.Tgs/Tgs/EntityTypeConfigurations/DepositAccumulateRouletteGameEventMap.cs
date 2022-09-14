using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class DepositAccumulateRouletteGameEventMap : IEntityTypeConfiguration<DepositAccumulateRouletteGameEvent>
{
    public void Configure(EntityTypeBuilder<DepositAccumulateRouletteGameEvent> builder)
    {
        _ = builder.ToTable("deposit_accumulate_roulette_game_events");

        _ = builder.Property(e => e.Id)
            .IsRequired();

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_deposit_accumulate_roulette_game_events");

        _ = builder.Property(e => e.BrandId)
            .IsRequired();

        _ = builder.Property(e => e.PlayerCode)
            .IsRequired();

        _ = builder.Property(e => e.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz")
            .HasDefaultValueSql("Now()");

        _ = builder.Property(e => e.PromotionId)
            .IsRequired();

        _ = builder.Property(e => e.ItemIndex)
            .IsRequired();

        _ = builder.Property(e => e.Bonus)
            .HasDefaultValue(0M)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(e => e.Date)
            .IsRequired();

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_game_events_brands_brand_id")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(e => e.PlayerCode)
            .HasConstraintName("fk_game_events_players_brand_id")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<Promotion>()
            .WithMany()
            .HasForeignKey(e => e.PromotionId)
            .HasConstraintName("fk_game_events_promotions_promotion_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
