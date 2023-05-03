using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class StationLetterDeliveryMap : IEntityTypeConfiguration<StationLetterDelivery>
{
    public void Configure(EntityTypeBuilder<StationLetterDelivery> builder)
    {
        _ = builder.ToTable("station_letter_delivery_box");

        _ = builder.HasKey(sd => sd.Id);

        _ = builder.Property(sd => sd.Sender)
            .IsRequired();
        _ = builder.Property(sd => sd.ReceiverType)
            .IsRequired();
        _ = builder.Property(sd => sd.Receiver)
            .IsRequired();
        _ = builder.Property(sd => sd.Subject)
            .IsRequired();
        _ = builder.Property(sd => sd.Content)
            .IsRequired();
        _ = builder.Property(sd => sd.ComeFrom);
        _ = builder.Property(sd => sd.SentOn)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}
