using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandPaymentAutoWithdrawMap : IEntityTypeConfiguration<BrandPaymentAutoWithdraw>
{
    public void Configure(EntityTypeBuilder<BrandPaymentAutoWithdraw> builder)
    {
        _ = builder.ToTable("brand_payment_auto_withdraw");

        _ = builder.HasKey(b => b.BrandId)
            .HasName("pk_brand_payment_auto_withdraw");

        _ = builder.Property(b => b.BrandPaymentCandidates)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();

        _ = builder.Property(b => b.EnableAutoWithdraw)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(b => b.AmountUpperLimit)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.SnapshotEventId)
            .IsRequired();
    }
}
