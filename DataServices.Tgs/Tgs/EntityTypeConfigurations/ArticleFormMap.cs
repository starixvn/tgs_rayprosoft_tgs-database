using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class ArticleFormMap : IEntityTypeConfiguration<ArticleForm>
{
    public void Configure(EntityTypeBuilder<ArticleForm> builder)
    {
        _ = builder.ToTable("article_forms");
        _ = builder.HasKey(a => a.Id);

        _ = builder.Property(a => a.BrandId)
            .IsRequired();
        _ = builder.Property(a => a.Description)
            .IsRequired();
        _ = builder.Property(a => a.LocalizedArticles)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(a => a.Modifier)
            .IsRequired();
        _ = builder.Property(a => a.Status)
            .IsRequired();
        _ = builder.Property(a => a.UpdatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(a => a.BrandId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_article_forms_brands");
    }
}
