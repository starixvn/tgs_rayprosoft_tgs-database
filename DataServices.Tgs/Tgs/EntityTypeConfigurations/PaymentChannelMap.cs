using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class PaymentChannelMap : IEntityTypeConfiguration<PaymentChannel>
{
    void IEntityTypeConfiguration<PaymentChannel>.Configure(EntityTypeBuilder<PaymentChannel> builder)
    {
        _ = builder.ToTable("payment_channels");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_payment_channels");

        _ = builder.Property(c => c.Code)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(128);
    }
}
