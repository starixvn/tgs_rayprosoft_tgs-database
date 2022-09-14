using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AnnouncementMap : IEntityTypeConfiguration<Announcement>
{
    void IEntityTypeConfiguration<Announcement>.Configure(EntityTypeBuilder<Announcement> builder)
    {
        _ = builder.ToTable("announcements");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_announcements");

        _ = builder.Property(c => c.Subject)
            .HasMaxLength(256);

        _ = builder.Property(c => c.Content)
            .HasMaxLength(4000);

        _ = builder.Property(c => c.Localization)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired()
            .HasDefaultValue("{}");

        _ = builder.Property(c => c.Remarks)
            .HasMaxLength(512);

        _ = builder.Property(c => c.DisplayOrder)
            .HasColumnType(ColumnTypes.SmallInt);

        _ = builder.Property(c => c.From)
            .IsRequired();

        _ = builder.Property(c => c.To)
            .IsRequired();

        _ = builder.Property(c => c.VerifiedByUsername)
            .HasMaxLength(32);

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder.Property(c => c.Type)
            .IsRequired()
            .HasDefaultValue("Marquee");

        _ = builder.HasOne(c => c.Brand)
            .WithMany(c => c.Announcements)
            .HasForeignKey(c => c.BrandId)
            .HasConstraintName("fk_announcements_brands_brand_id");

        _ = builder.HasIndex(c => c.BrandId)
            .HasDatabaseName("ix_announcements_brand_id");
    }
}
