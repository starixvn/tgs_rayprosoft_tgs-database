using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class OfflineDepositEventMap : IEntityTypeConfiguration<OfflineDepositEvent>
{
    public void Configure(EntityTypeBuilder<OfflineDepositEvent> builder)
    {
        _ = builder.ToTable("offline_deposit_events");

        _ = builder.HasKey(od => od.Id);

        _ = builder.Property(od => od.PlayerCode)
            .IsRequired();
        _ = builder.Property(od => od.BrandId)
            .IsRequired();
        _ = builder.Property(od => od.BonusAmount)
            .IsRequired();
        _ = builder.Property(od => od.BucketAmount)
            .IsRequired();
        _ = builder.Property(od => od.PromotionId)
            .IsRequired();
        _ = builder.Property(od => od.DepositFormId)
            .IsRequired();
        _ = builder.Property(od => od.Settings)
            .HasColumnType("jsonb")
            .IsRequired();
        _ = builder.Property(od => od.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();
    }
}
