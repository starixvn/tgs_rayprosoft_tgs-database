#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class DraftFormMap : IEntityTypeConfiguration<DraftForm>
{
    public void Configure(EntityTypeBuilder<DraftForm> builder)
    {
        _ = builder.ToTable("draft_forms");
        _ = builder.HasKey(d => d.Id);

        _ = builder.Property(d => d.BrandId)
            .IsRequired();
        _ = builder.Property(d => d.Description)
            .IsRequired();
        _ = builder.Property(d => d.LocalizedArticles)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(d => d.Modifier)
            .IsRequired();
        _ = builder.Property(d => d.Status)
            .IsRequired();
        _ = builder.Property(d => d.PublishDate)
            .HasColumnType("date");
        _ = builder.Property(d => d.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(a => a.UpdatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(d => d.BrandId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("fk_draft_forms_brands");
    }
}
