using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class SmsSettingMap : IEntityTypeConfiguration<SmsSetting>
{
    public void Configure(EntityTypeBuilder<SmsSetting> builder)
    {
        _ = builder.ToTable("sms_settings");

        _ = builder.HasKey(s => s.Id);
        
        _ = builder.Property(s => s.Name)
            .HasMaxLength(256)
            .IsRequired();
        _ = builder.Property(s => s.Code)
            .HasMaxLength(50)
            .IsRequired();
        _ = builder.Property(s => s.Setting)
            .HasColumnType(ColumnTypes.Jsonb)
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