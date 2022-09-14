using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandLanguageMap : IEntityTypeConfiguration<BrandLanguage>
{
    void IEntityTypeConfiguration<BrandLanguage>.Configure(EntityTypeBuilder<BrandLanguage> builder)
    {
        _ = builder.ToTable("brand_languages");

        _ = builder.HasKey(bl => new { bl.BrandId, bl.CultureCode })
            .HasName("pk_brand_languages");

        _ = builder.Property(bl => bl.CultureCode)
            .HasMaxLength(6)
            .IsUnicode();

        _ = builder.Property(bl => bl.BrandCultureCode)
            .HasMaxLength(6)
            .IsRequired();

        _ = builder
            .HasOne(bl => bl.Brand)
            .WithMany(b => b.Languages)
            .HasForeignKey(bl => bl.BrandId)
            .HasConstraintName("fk_brand_languages_brands_brand_id");

        _ = builder
            .HasOne(bl => bl.Language)
            .WithMany(l => l.BrandLanguages)
            .HasForeignKey(bl => bl.CultureCode)
            .HasConstraintName("fk_brand_languages_languages_culture_code");

        _ = builder.HasIndex(e => e.CultureCode)
            .HasDatabaseName("ix_brand_languages_culture_code");
    }
}
