using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class OfflineLoginRewardEventMap : IEntityTypeConfiguration<OfflineLoginRewardEvent>
{
    public void Configure(EntityTypeBuilder<OfflineLoginRewardEvent> builder)
    {
        _ = builder.ToTable("offline_login_reward_events");

        _ = builder.Property(e => e.Id)
            .IsRequired();

        _ = builder.HasKey(e => e.Id)
            .HasName("pk_offline_login_reward_events");

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

        _ = builder.Property(e => e.LoggedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        _ = builder.Property(e => e.Bonus)
            .HasPrecision(18, 6)
            .IsRequired();
        
        _ = builder.Property(e => e.Bucket)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(e => e.BrandId)
            .HasConstraintName("fk_offline_login_reward_events_brands_brand_id")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(e => e.PlayerCode)
            .HasConstraintName("fk_offline_login_reward_events_players_brand_id")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasOne<Promotion>()
            .WithMany()
            .HasForeignKey(e => e.PromotionId)
            .HasConstraintName("fk_offline_login_reward_events_promotions_promotion_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}