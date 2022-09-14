using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class PaymentMap : IEntityTypeConfiguration<Payment>
{
    void IEntityTypeConfiguration<Payment>.Configure(EntityTypeBuilder<Payment> builder)
    {
        _ = builder.ToTable("payments");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_payments");

        _ = builder.Property(c => c.Code)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(128);

        _ = builder.Property(c => c.ExtendData)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .HasDefaultValueSql("0")
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");
    }
}
