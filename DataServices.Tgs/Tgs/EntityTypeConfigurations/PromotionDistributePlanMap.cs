using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionDistributePlanMap : IEntityTypeConfiguration<PromotionDistributePlan>
{
    public void Configure(EntityTypeBuilder<PromotionDistributePlan> builder)
    {
        _ = builder.ToTable("promotion_distribute_plans");

        _ = builder.HasKey(pdp => pdp.Id)
            .HasName("pk_promotion_distribute_plans");

        _ = builder.Property(pdp => pdp.ConditionHash);
        _ = builder.Property(pdp => pdp.BrandId);
        _ = builder.Property(pdp => pdp.PromotionId);
        _ = builder.Property(pdp => pdp.Detail)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.HasOne<Promotion>()
            .WithMany()
            .HasForeignKey(pdp => pdp.PromotionId)
            .HasConstraintName("fk_promotion_distribute_plans_promotions")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasIndex(pdp => new { pdp.BrandId, pdp.PromotionId, pdp.ConditionHash })
            .IsUnique()
            .HasDatabaseName("ux_promotion_distrubute_plans");
    }
}
