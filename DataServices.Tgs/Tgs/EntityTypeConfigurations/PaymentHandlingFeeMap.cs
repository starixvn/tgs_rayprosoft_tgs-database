using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PaymentHandlingFeeMap : IEntityTypeConfiguration<PaymentHandlingFee>
{
    public void Configure(EntityTypeBuilder<PaymentHandlingFee> builder)
    {
        _ = builder.ToTable("payment_handling_fees");
        _ = builder.HasKey(phf => phf.Id)
            .HasName("pk_payment_handling_fees_id");

        _ = builder.Property(phf => phf.Id)
            .IsRequired();
        _ = builder.Property(phf => phf.Type)
            .IsRequired();
        _ = builder.Property(phf => phf.Amount)
            .IsRequired();
        _ = builder.Property(phf => phf.Fee)
            .IsRequired();
        _ = builder.Property(phf => phf.FormId)
            .IsRequired();
        _ = builder.Property(phf => phf.UserType)
            .IsRequired();
        _ = builder.Property(phf => phf.UserId)
            .IsRequired();
        _ = builder.Property(phf => phf.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(phf => phf.ApprovedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(phf => phf.RecordedOn)
            .IsRequired()
            .HasColumnType("timestamptz")
            .HasDefaultValueSql("Now()");
        _ = builder.Property(phf => phf.Remark)
            .HasColumnType(ColumnTypes.Jsonb);
        _ = builder.Property(phf => phf.BrandId)
            .IsRequired();

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(phf => phf.BrandId)
            .HasConstraintName("fk_payment_handling_fees_brands_brand_id")
            .OnDelete(DeleteBehavior.Cascade);

        _ = builder.HasIndex(phf => phf.FormId)
            .HasDatabaseName("ix_payment_handling_fees_form_id")
            .IncludeProperties(phf => new { phf.Amount, phf.Fee, phf.RecordedOn });

        _ = builder.HasIndex(phf => new { phf.RecordedOn, phf.FormId })
            .HasDatabaseName("ix_payment_handling_fees_recorded_on_form_id")
            .IncludeProperties(phf => new { phf.Amount, phf.Fee });
    }
}
