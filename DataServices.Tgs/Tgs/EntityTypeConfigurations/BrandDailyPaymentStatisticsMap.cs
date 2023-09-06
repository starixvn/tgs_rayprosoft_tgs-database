using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandDailyPaymentStatisticsMap : BaseConfiguration, IEntityTypeConfiguration<BrandDailyPaymentStatistics>
{
    public void Configure(EntityTypeBuilder<BrandDailyPaymentStatistics> builder)
    {
        _ = builder.ToTable("brand_daily_payment_statistics");

        _ = builder.HasKey(b => new { b.ReportDate, b.BrandId });

        _ = builder.Property(b => b.ReportDate)
            .IsRequired();
        _ = builder.Property(b => b.BrandId)
            .IsRequired();
        _ = builder.Property(b => b.FirstDepositPlayers)
            .IsRequired();
        _ = builder.Property(b => b.UndepositAgainPlayers)
            .IsRequired();
        _ = builder.Property(b => b.DepositPlayers)
            .IsRequired();

        _ = builder.Property(a => a.DailyDepositAmount);
        _ = builder.Property(a => a.DailyDepositHandlingFee);
        _ = builder.Property(a => a.DailyWithdrawAmount);
        _ = builder.Property(a => a.DailyWithdrawHandlingFee);

        _ = builder.Property(d => d.DailyDepositTotalCount);
        _ = builder.Property(d => d.DailyDepositApprovedCount);
        _ = builder.Property(d => d.DailyDepositRejectCount);
    }
}
