using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class StationLetter2Map : IEntityTypeConfiguration<StationLetter2>
{
    public void Configure(EntityTypeBuilder<StationLetter2> builder)
    {
        _ = builder.ToTable("station_letter2");

        _ = builder.HasKey(s => s.Id);

        _ = builder.Property(s => s.Sender)
            .IsRequired();
        _ = builder.Property(s => s.Receiver)
            .IsRequired();
        _ = builder.Property(s => s.Subject)
            .IsRequired();
        _ = builder.Property(s => s.Quotation);
        _ = builder.Property(s => s.Content)
            .IsRequired();
        _ = builder.Property(s => s.ComeFrom);
        _ = builder.Property(s => s.SentOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(s => s.ReceivedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(s => s.HaveRead)
            .IsRequired()
            .HasDefaultValue(false);
        _ = builder.Property(s => s.Replied)
            .IsRequired()
            .HasDefaultValue(false);
    }
}
