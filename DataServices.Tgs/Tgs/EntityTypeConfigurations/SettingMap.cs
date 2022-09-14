using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class SettingMap : IEntityTypeConfiguration<Setting>
{
    void IEntityTypeConfiguration<Setting>.Configure(EntityTypeBuilder<Setting> builder)
    {
        _ = builder.ToTable("settings");

        _ = builder.HasKey(c => c.Key)
            .HasName("pk_settings");

        _ = builder.Property(c => c.Key)
            .HasMaxLength(32)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Value)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(256);

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
    }
}
