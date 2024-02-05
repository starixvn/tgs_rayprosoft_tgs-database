using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class FiveMinutesPaymentStatisticsDeltaMap : IEntityTypeConfiguration<FiveMinutesPaymentStatisticsDelta>
{
    public void Configure(EntityTypeBuilder<FiveMinutesPaymentStatisticsDelta> builder)
    {
        _ = builder.ToTable("five_minutes_payment_statistics_delta", "dbo");

        _ = builder.HasKey(f => f.Id);

        _ = builder.Property(f => f.TimePoint)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(f => f.UserId)
            .IsRequired();
        _ = builder.Property(f => f.UserType)
            .IsRequired();
        _ = builder.Property(f => f.BrandId)
            .IsRequired();
        _ = builder.Property(f => f.DepositAmount);
        _ = builder.Property(f => f.DepositCount);
        _ = builder.Property(f => f.DepositHandlingFee);
        _ = builder.Property(f => f.WithdrawAmount);
        _ = builder.Property(f => f.WithdrawCount);
        _ = builder.Property(f => f.WithdrawHandlingFee);
    }
}
