using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class DepositFormMap : IEntityTypeConfiguration<DepositForm>
{
    public void Configure(EntityTypeBuilder<DepositForm> builder)
    {
        _ = builder.ToTable("deposit_forms");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_deposit_forms");

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.ReviewedUserId);

        _ = builder.Property(c => c.ReviewedUserName);

        _ = builder.Property(c => c.ReviewedOn);

        _ = builder.Property(c => c.Amount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.ActualAmount)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.HandlingFee)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.BrandPaymentId)
            .IsRequired();

        _ = builder.Property(c => c.PromotionId);

        _ = builder.Property(c => c.Status)
            .IsRequired()
            .HasDefaultValue(0);

        _ = builder.Property(c => c.Remark);

        _ = builder.Property(c => c.ApplyInfo)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(c => c.PaymentReturn)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");

        _ = builder.Property(c => c.ThirdPartyOrderNo);

        _ = builder.Property(c => c.OrderNo)
            .HasMaxLength(50);

        _ = builder.Property(df => df.PromotionPlayerId);

        _ = builder
            .HasOne(c => c.Player)
            .WithMany()
            .HasForeignKey(c => c.PlayerCode)
            .HasConstraintName("fk_deposit_forms_players_player_code");

        _ = builder.HasIndex(c => c.PlayerCode)
            .HasDatabaseName("ix_deposit_forms_playerCode");

        _ = builder
            .HasOne(c => c.Brand)
            .WithMany()
            .HasForeignKey(c => c.BrandId)
            .HasConstraintName("fk_deposit_froms_brands_id");

        _ = builder.HasIndex(c => c.BrandId)
            .HasDatabaseName("ix_deposit_forms_brandId");

        _ = builder
            .HasOne(c => c.BrandPayment)
            .WithMany()
            .HasForeignKey(c => c.BrandPaymentId)
            .HasConstraintName("fk_deposit_forms_brand_payments_id");

        _ = builder.HasIndex(c => c.BrandPaymentId)
            .HasDatabaseName("ix_deposit_forms_brand_payment_id");
    }
}
