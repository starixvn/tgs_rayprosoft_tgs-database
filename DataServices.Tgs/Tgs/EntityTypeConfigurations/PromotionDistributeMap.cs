using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionDistributeMap : IEntityTypeConfiguration<PromotionDistribute>
{
    public void Configure(EntityTypeBuilder<PromotionDistribute> builder)
    {
        _ = builder.ToTable("promotion_distributes");

        _ = builder.HasKey(pd => pd.Id)
            .HasName("pk_promotion_distributes");

        _ = builder.Property(pd => pd.PlanId);
        _ = builder.Property(pd => pd.PlayerCode);
        _ = builder.Property(pd => pd.BrandId);
        _ = builder.Property(pd => pd.PromotionId);
        _ = builder.Property(pd => pd.BonusAmount);
        _ = builder.Property(pd => pd.Bucket);
        _ = builder.Property(pd => pd.Distributor);
        _ = builder.Property(pd => pd.SentOn);
        _ = builder.Property(pd => pd.CreatedOn);

        _ = builder.HasOne<Promotion>()
            .WithMany()
            .HasForeignKey(pd => pd.PromotionId)
            .HasConstraintName("fk_promotion_distributes_promotions")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(pd => new { pd.PlayerCode, pd.PlanId })
            .HasFilter("plan_id IS NOT NULL")
            .IsUnique()
            .HasDatabaseName("ux_promotion_distributes");
    }
}
