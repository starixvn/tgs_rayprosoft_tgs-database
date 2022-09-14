using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class PaymentMethodMap : IEntityTypeConfiguration<PaymentMethod>
{
    void IEntityTypeConfiguration<PaymentMethod>.Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        _ = builder.ToTable("payment_methods");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_payment_methods");

        _ = builder.Property(c => c.Code)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(c => c.BankType)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(128);
    }
}
