using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class TransferBalanceFormMap : IEntityTypeConfiguration<TransferBalanceForm>
{
    public void Configure(EntityTypeBuilder<TransferBalanceForm> builder)
    {
        builder.ToTable("transfer_balance_forms");

        builder.HasKey(form => form.Id)
            .HasName("pk_transfer_balance_forms");

        builder.Property(form => form.BrandId)
            .IsRequired();
        builder.Property(form => form.DraweeType)
            .IsRequired();
        builder.Property(form => form.Drawee)
            .IsRequired();
        builder.Property(form => form.PayeeType)
            .IsRequired();
        builder.Property(form => form.Payee)
            .IsRequired();
        builder.Property(form => form.Amount)
            .HasPrecision(18, 6)
            .IsRequired();

        builder.Property(form => form.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz")
            .HasDefaultValueSql("Now()");

        builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(form => form.BrandId)
            .HasConstraintName("fk_transfer_balance_forms_brands_brand_id")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
