using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDailyPaymentStatisticsMap : BaseConfiguration, IEntityTypeConfiguration<AgentDailyPaymentStatistics>
{
    public void Configure(EntityTypeBuilder<AgentDailyPaymentStatistics> builder)
    {
        _ = builder.ToTable("agent_daily_payment_statistics");

        _ = builder.HasKey(a => new { a.ReportDate, a.BrandId, a.AgentId });

        _ = builder.Property(a => a.ReportDate)
            .IsRequired();
        _ = builder.Property(a => a.BrandId)
            .IsRequired();
        _ = builder.Property(a => a.AgentId)
            .IsRequired();

        _ = builder.Property(a => a.FirstDepositPlayers)
            .IsRequired();
        _ = builder.Property(a => a.UndepositAgainPlayers)
            .IsRequired();
        _ = builder.Property(a => a.DepositPlayers)
            .IsRequired();

        _ = builder.Property(a => a.DailyDepositAmount);
        _ = builder.Property(a => a.DailyDepositHandlingFee);
        _ = builder.Property(a => a.DailyWithdrawAmount);
        _ = builder.Property(a => a.DailyWithdrawHandlingFee);
    }
}
