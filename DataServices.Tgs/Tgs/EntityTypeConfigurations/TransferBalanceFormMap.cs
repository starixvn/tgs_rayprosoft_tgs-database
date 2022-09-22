using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class TransferBalanceFormMap : IEntityTypeConfiguration<TransferBalanceForm>
{
    public void Configure(EntityTypeBuilder<TransferBalanceForm> builder)
    {
        _ = builder.ToTable("transfer_balance_forms");

        _ = builder.HasKey(form => form.Id)
            .HasName("pk_transfer_balance_forms");

        _ = builder.Property(form => form.BrandId)
            .IsRequired();
        _ = builder.Property(form => form.DraweeType)
            .IsRequired();
        _ = builder.Property(form => form.Drawee)
            .IsRequired();
        _ = builder.Property(form => form.PayeeType)
            .IsRequired();
        _ = builder.Property(form => form.Payee)
            .IsRequired();
        _ = builder.Property(form => form.Amount)
            .HasPrecision(18, 6)
            .IsRequired();
        _ = builder.Property(form => form.IncludeInNetProfit)
            .IsRequired();

        _ = builder.Property(form => form.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz")
            .HasDefaultValueSql("Now()");
        _ = builder.Property(form => form.CreatedUserId)
            .IsRequired();

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(form => form.BrandId)
            .HasConstraintName("fk_transfer_balance_forms_brands_brand_id")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
