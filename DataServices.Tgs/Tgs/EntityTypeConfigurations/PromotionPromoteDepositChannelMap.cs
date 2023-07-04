#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionPromoteDepositChannelMap : IEntityTypeConfiguration<PromotionPromoteDepositChannel>
{
    public void Configure(EntityTypeBuilder<PromotionPromoteDepositChannel> builder)
    {
        _ = builder.ToTable("promotion_promote_deposit_channels");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_promotion_promote_deposit_channels");

        _ = builder.Property(p => p.PlayerCode)
            .IsRequired();
        _ = builder.Property(p => p.FormId)
            .IsRequired();
        _ = builder.Property(p => p.Bonus)
            .IsRequired();
        _ = builder.Property(p => p.BucketAmount)
            .IsRequired();
        _ = builder.Property(p => p.VipLevel)
            .IsRequired();
        _ = builder.Property(p => p.DistributePlanId)
            .IsRequired();
        _ = builder.Property(p => p.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(p => p.PromotionId)
            .IsRequired();
    }
}
