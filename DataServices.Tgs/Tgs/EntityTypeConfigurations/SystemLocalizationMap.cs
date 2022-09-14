using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class SystemLocalizationMap : IEntityTypeConfiguration<SystemLocalization>
{
    public void Configure(EntityTypeBuilder<SystemLocalization> builder)
    {
        _ = builder
            .HasKey(tb => new
            {
                tb.SystemCode,
                tb.CultureCode,
                tb.MessageId
            })
            .HasName("pk_system_localizations");

        _ = builder.Property(tb => tb.SystemCode)
            .IsRequired();

        _ = builder.Property(tb => tb.CultureCode)
            .IsRequired();

        _ = builder.Property(tb => tb.MessageId)
            .IsRequired();

        _ = builder.Property(tb => tb.Text)
            .IsRequired();
    }
}
