using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerDailyPaymentStatisticsMap : BaseConfiguration, IEntityTypeConfiguration<PlayerDailyPaymentStatistics>
{
    public void Configure(EntityTypeBuilder<PlayerDailyPaymentStatistics> builder)
    {
        _ = builder.ToTable("player_daily_payment_statistics");

        _ = builder.HasKey(p => new { p.ReportDate, p.PlayerCode });

        _ = builder.Property(p => p.ReportDate)
            .IsRequired();
        _ = builder.Property(p => p.PlayerCode)
            .IsRequired();

        _ = builder.Property(p => p.DailyDepositCount);
        _ = builder.Property(p => p.DailyDepositAmount);
        _ = builder.Property(p => p.TotalDepositCount);
        _ = builder.Property(p => p.TotalDepositAmount);
        _ = builder.Property(p => p.DailyWithdrawCount);
        _ = builder.Property(p => p.DailyWithdrawAmount);
        _ = builder.Property(p => p.TotalWithdrawAmount);
        _ = builder.Property(p => p.TotalWithdrawCount);
        _ = builder.Property(p => p.FirstDepositOn)
            .HasColumnType("timestamptz");
        _ = builder.Property(p => p.FirstDepositAmount);

        _ = builder.Property(a => a.FirstDepositHandlingFee);
        _ = builder.Property(a => a.DailyDepositHandlingFee);
        _ = builder.Property(a => a.DailyWithdrawHandlingFee);
        _ = builder.Property(a => a.TotalDepositHandlingFee);
        _ = builder.Property(a => a.TotalWithdrawHandlingFee);
    }
}
