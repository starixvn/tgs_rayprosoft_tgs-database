using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class SocialMediaSettingMap : IEntityTypeConfiguration<SocialMediaSetting>
{
    public void Configure(EntityTypeBuilder<SocialMediaSetting> builder)
    {
        _ = builder.ToTable("social_media_settings");

        _ = builder.HasKey(s => s.Id);

        _ = builder.Property(s => s.BrandId)
            .IsRequired();
        _ = builder.Property(s => s.Name)
            .HasMaxLength(256)
            .IsRequired();
        _ = builder.Property(s => s.Type)
            .HasMaxLength(128)
            .IsRequired();
        _ = builder.Property(s => s.Url)
            .IsRequired();
        _ = builder.Property(s => s.Order)
            .IsRequired();
        _ = builder.Property(s => s.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();
        _ = builder.Property(s => s.CreatedBy)
            .HasMaxLength(256);
        _ = builder.Property(s => s.UpdatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();
        _ = builder.Property(s => s.UpdatedBy)
            .HasMaxLength(256)
            .IsRequired();
    }
}