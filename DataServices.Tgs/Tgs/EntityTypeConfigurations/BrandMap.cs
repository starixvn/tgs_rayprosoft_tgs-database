using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandMap : BaseConfiguration, IEntityTypeConfiguration<Brand>
{
    void IEntityTypeConfiguration<Brand>.Configure(EntityTypeBuilder<Brand> builder)
    {
        _ = builder.ToTable("brands");

        ConfigureBaseProperties<Brand, Guid>(builder, "pk_brands");

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(256);

        _ = builder.Property(c => c.OperationalEmail)
            .HasMaxLength(128);

        _ = builder.Property(c => c.ClientId)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(c => c.SecretKey)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.ApiKey)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.TimeZoneId)
            .HasMaxLength(256);

        _ = builder.Property(c => c.EnableSms)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(c => c.EnableAgentSms)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(b => b.EnableSmsRegisterFlow)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(b => b.EnableEmailRegisterFlow)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(b => b.EnableBankInfoRegisterFlow)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(b => b.EnablePlayerIdentity)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(c => c.SmsVendorCode);

        _ = builder.Property(c => c.SmsVendorSettings)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(c => c.SettlementIntervalType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.AgentDividendType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.PreviousSettlementFrom)
            .IsRequired();

        _ = builder.Property(c => c.CurrentSettlementFrom)
            .IsRequired();

        _ = builder.Property(c => c.NextSettlementFrom)
            .IsRequired();

        _ = builder.Property(c => c.PreviousSettlementTo)
            .IsRequired();

        _ = builder.Property(c => c.CurrentSettlementTo)
            .IsRequired();

        _ = builder.Property(c => c.NextSettlementTo)
            .IsRequired();

        _ = builder.Property(c => c.LogoInfo)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(c => c.PlatformCharge)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.AutoClearWageringRequirementBalance)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.WithdrawHandlingFeeRateTenPercentile)
            .IsRequired()
            .HasDefaultValue(0M);

        _ = builder.Property(c => c.DepositHandlingFeeRateTenPercentile)
            .IsRequired()
            .HasDefaultValue(0M);

        _ = builder.Property(c => c.PlayerRegisterFlowSettings)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(c => c.DepositPaymentLockEnabled)
            .HasDefaultValue(false)
            .IsRequired();

        _ = builder.Property(c => c.TimeSpanMinutes)
            .HasDefaultValue(480);

        _ = builder.HasOne(c => c.Licensee)
            .WithMany(c => c.Brands)
            .HasForeignKey(c => c.LicenseeId)
            .HasConstraintName("fk_brands_licensees_licensee_id");

        _ = builder.HasIndex(c => c.LicenseeId)
            .HasDatabaseName("ix_brands_licensee_id");
    }
}
