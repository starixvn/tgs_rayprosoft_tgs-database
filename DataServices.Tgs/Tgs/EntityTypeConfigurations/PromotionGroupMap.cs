using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PromotionGroupMap : IEntityTypeConfiguration<PromotionGroup>
{
    public void Configure(EntityTypeBuilder<PromotionGroup> builder)
    {
        _ = builder.ToTable("promotion_groups");

        _ = builder.HasKey(pg => pg.Name);

        _ = builder.Property(pg => pg.Translate)
            .HasColumnType("jsonb");
    }
}
