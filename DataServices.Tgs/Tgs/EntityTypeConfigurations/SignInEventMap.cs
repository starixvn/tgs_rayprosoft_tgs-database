using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class SignInEventMap : IEntityTypeConfiguration<SignInEvent>
{
    public void Configure(EntityTypeBuilder<SignInEvent> builder)
    {
        _ = builder.ToTable("sign_in_events");

        _ = builder.Property(s => s.Id)
            .IsRequired();

        _ = builder.HasKey(s => s.Id)
            .HasName("pk_sign_in_events");

        _ = builder.Property(s => s.BrandId)
            .IsRequired();
        _ = builder.Property(s => s.PlayerCode)
            .IsRequired();
        _ = builder.Property(s => s.Date)
            .IsRequired()
            .HasColumnType("date");
        _ = builder.Property(s => s.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz")
            .HasDefaultValueSql("Now()");
        _ = builder.Property(s => s.Combo)
            .IsRequired()
            .HasDefaultValue(1);

        _ = builder.Property(s => s.PromotionId)
            .IsRequired();

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(s => s.BrandId)
            .HasConstraintName("fk_sign_in_events_brands_brand_id")
            .OnDelete(DeleteBehavior.Cascade);
        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(s => s.PlayerCode)
            .HasConstraintName("fk_sign_in_events_players_brand_id")
            .OnDelete(DeleteBehavior.Cascade);
        _ = builder.HasOne<Promotion>()
            .WithMany()
            .HasForeignKey(s => s.PromotionId)
            .HasConstraintName("fk_sign_in_events_promotions_promotion_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
