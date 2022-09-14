using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class LicenseeLanguageMap : IEntityTypeConfiguration<LicenseeLanguage>
{
    void IEntityTypeConfiguration<LicenseeLanguage>.Configure(EntityTypeBuilder<LicenseeLanguage> builder)
    {
        _ = builder.ToTable("licensee_languages");

        _ = builder.HasKey(bl => new { bl.LicenseeId, bl.CultureCode })
            .HasName("pk_licensee_languages");

        _ = builder.Property(bl => bl.CultureCode)
            .HasMaxLength(6);

        _ = builder
            .HasOne(bl => bl.Licensee)
            .WithMany(b => b.Languages)
            .HasForeignKey(bl => bl.LicenseeId)
            .HasConstraintName("fk_licensee_languages_licensees_licensee_id");

        _ = builder
            .HasOne(bl => bl.Language)
            .WithMany(l => l.LicenseeLanguages)
            .HasForeignKey(bl => bl.CultureCode)
            .HasConstraintName("fk_licensee_languages_languages_culture_code");
    }
}
