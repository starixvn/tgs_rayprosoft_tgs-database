using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class PromotionDistributeLogMap : IEntityTypeConfiguration<PromotionDistributeLog>
{
    public void Configure(EntityTypeBuilder<PromotionDistributeLog> builder)
    {
        _ = builder.ToTable("promotion_distribute_logs");

        _ = builder.HasKey(p => p.Id);

        _ = builder.Property(p => p.DistributeId)
            .IsRequired();
        _ = builder.Property(p => p.ChangeSets)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();
        _ = builder.Property(p => p.Action)
            .IsRequired();
        _ = builder.Property(p => p.CreatedOn)
            .HasColumnType("timestamptz")
            .HasDefaultValueSql("now()")
            .IsRequired();
    }
}
