using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class FiveMinutesPaymentStatisticsMap : IEntityTypeConfiguration<FiveMinutesPaymentStatistics>
{
    public void Configure(EntityTypeBuilder<FiveMinutesPaymentStatistics> builder)
    {
        _ = builder.ToTable("five_minutes_payment_statistics", "dbo");

        _ = builder.HasKey(f => new { f.TimePoint, f.UserId, f.UserType });

        _ = builder.Property(f => f.BrandId)
            .IsRequired();
        _ = builder.Property(f => f.DepositAmount);
        _ = builder.Property(f => f.DepositCount);
        _ = builder.Property(f => f.DepositHandlingFee);
        _ = builder.Property(f => f.FirstDepositAmount);
        _ = builder.Property(f => f.FirstDepositHandlingFee);
        _ = builder.Property(f => f.FirstDepositOn)
            .HasColumnType("timestamptz");
        _ = builder.Property(f => f.WithdrawAmount);
        _ = builder.Property(f => f.WithdrawCount);
        _ = builder.Property(f => f.WithdrawHandlingFee);
        _ = builder.Property(f => f.FirstWithdrawAmount);
        _ = builder.Property(f => f.FirstWithdrawHandlingFee);
        _ = builder.Property(f => f.FirstWithdrawOn)
            .HasColumnType("timestamptz");
    }
}
