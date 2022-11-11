using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionTypeMap : IEntityTypeConfiguration<PromotionType>
{
    public void Configure(EntityTypeBuilder<PromotionType> builder)
    {
        _ = builder.ToTable("promotion_types");

        _ = builder.HasKey(pt => pt.Name);

        _ = builder.Property(pt => pt.Extend)
            .HasColumnType("jsonb");
        _ = builder.Property(pt => pt.Translate)
            .HasColumnType("jsonb");
    }
}
