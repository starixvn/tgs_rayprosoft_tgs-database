using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerPaymentOverviewMap : IEntityTypeConfiguration<PlayerPaymentOverview>
{
    public void Configure(EntityTypeBuilder<PlayerPaymentOverview> builder)
    {
        _ = builder.ToTable("player_payment_overview");

        _ = builder.HasKey(pt => pt.PlayerCode);

        _ = builder.Property(pt => pt.TotalDepositAmount)
            .IsRequired();
        _ = builder.Property(pt => pt.TotalWithdrawAmount)
            .IsRequired();
        _ = builder.Property(pt => pt.FirstDepositOn)
            .HasColumnType("timestamptz");
        _ = builder.Property(pt => pt.FirstDepositAmount);
        _ = builder.Property(pt => pt.FirstDepositHandlingFee);
        _ = builder.Property(pt => pt.FirstWithdrawOn)
            .HasColumnType("timestamptz");
        _ = builder.Property(pt => pt.FirstWithdrawAmount);
        _ = builder.Property(pt => pt.FirstWithdrawHandlingFee);
        _ = builder.Property(pt => pt.RecordedBy);
        _ = builder.Property(pt => pt.TotalDepositCount)
            .HasDefaultValue(0)
            .IsRequired();
        _ = builder.Property(pt => pt.TotalWithdrawCount)
            .HasDefaultValue(0)
            .IsRequired();
    }
}