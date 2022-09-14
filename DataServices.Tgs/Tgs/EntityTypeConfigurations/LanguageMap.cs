using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class LanguageMap : IEntityTypeConfiguration<Language>
{
    void IEntityTypeConfiguration<Language>.Configure(EntityTypeBuilder<Language> builder)
    {
        _ = builder.ToTable("languages");

        _ = builder.HasKey(l => l.CultureCode)
            .HasName("pk_languages");

        _ = builder.Property(l => l.CultureCode)
            .HasMaxLength(6)
            .IsRequired();

        _ = builder.Property(l => l.LanguageCode)
            .HasMaxLength(10)
            .IsRequired();

        _ = builder.Property(l => l.Name)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(l => l.LocalizedName)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(l => l.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(l => l.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(l => l.CreatedOn)
            .IsRequired();

        _ = builder.Property(l => l.UpdatedOn)
            .IsRequired();
    }
}
