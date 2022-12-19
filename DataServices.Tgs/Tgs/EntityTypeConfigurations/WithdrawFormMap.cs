using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class WithdrawFormMap : IEntityTypeConfiguration<WithdrawForm>
{
    public void Configure(EntityTypeBuilder<WithdrawForm> builder)
    {
        _ = builder.ToTable("withdraw_forms");

        _ = builder.HasKey(w => w.Id)
            .HasName("pk_withdraw_forms");

        _ = builder.Property(w => w.BrandId)
            .IsRequired();

        _ = builder.Property(w => w.UserId);

        _ = builder.Property(w => w.UserName);

        _ = builder.Property(w => w.UserType)
            .IsRequired()
            .HasDefaultValue(0);

        _ = builder.Property(w => w.ReviewedUserId);

        _ = builder.Property(w => w.ReviewedUserName);

        _ = builder.Property(w => w.ReviewedOn);

        _ = builder.Property(w => w.PaidUserId);

        _ = builder.Property(w => w.PaidUserName);

        _ = builder.Property(w => w.PaidOn);

        _ = builder.Property(w => w.Amount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(w => w.ActualAmount)
            .HasPrecision(18, 6);

        _ = builder.Property(w => w.HandlingFee)
            .HasPrecision(18, 6);

        _ = builder.Property(w => w.BrandPaymentId);

        _ = builder.Property(w => w.Status)
            .IsRequired()
            .HasDefaultValue(0);

        _ = builder.Property(w => w.Remark);

        _ = builder.Property(w => w.Note);

        _ = builder.Property(w => w.BankInfoId)
            .IsRequired();

        _ = builder.Property(w => w.BankInfo)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();

        _ = builder.Property(w => w.ApplyInfo)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(w => w.PaymentReturn)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(w => w.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");

        _ = builder.Property(w => w.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");

        _ = builder.Property(w => w.SnapshotEventId);

        _ = builder.Property(w => w.ThirdPartyOrderNo);

        _ = builder.Property(w => w.OrderNo)
            .HasMaxLength(50);

        _ = builder.HasOne(w => w.Brand)
            .WithMany()
            .HasForeignKey(w => w.BrandId)
            .HasConstraintName("fk_withdraw_forms_brands_brand_id");

        _ = builder.HasIndex(w => w.BrandId)
            .HasDatabaseName("ix_withdraw_forms_brand_id");

        _ = builder.HasOne(w => w.BrandPayment)
            .WithMany()
            .HasForeignKey(w => w.BrandPaymentId)
            .HasConstraintName("fk_withdraw_forms_brand_payments_brand_payment_id");

        _ = builder.HasIndex(w => w.BrandPaymentId)
            .HasDatabaseName("ix_withdraw_froms_brand_payment_id");
    }
}
