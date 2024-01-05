using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class DepositPromotionCalculatePairMap : IEntityTypeConfiguration<DepositPromotionCalculatePair>
{
    public void Configure(EntityTypeBuilder<DepositPromotionCalculatePair> builder)
    {
        _ = builder.ToTable("deposit_promotion_calculate_pairs");

        _ = builder.HasKey(dp => dp.PromotionId);

        _ = builder.Property(dp => dp.CalculateId)
            .IsRequired();
    }
}
