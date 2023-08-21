using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandPaymentAutoWithdrawEventSourceMap : IEntityTypeConfiguration<BrandPaymentAutoWithdrawEventSource>
{
    public void Configure(EntityTypeBuilder<BrandPaymentAutoWithdrawEventSource> builder)
    {
        _ = builder.ToTable("brand_payment_auto_withdraw_event_source");

        _ = builder.HasKey(b => b.Id);

        _ = builder.Property(b => b.BrandId)
            .IsRequired();

        _ = builder.Property(b => b.ChangeSets)
            .HasColumnType("jsonb")
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();

        _ = builder.Property(b => b.ModifyUser);
    }
}
