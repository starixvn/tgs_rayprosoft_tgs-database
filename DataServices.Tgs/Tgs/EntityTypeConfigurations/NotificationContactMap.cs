using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class NotificationContactMap : IEntityTypeConfiguration<NotificationContact>
{
    void IEntityTypeConfiguration<NotificationContact>.Configure(EntityTypeBuilder<NotificationContact> builder)
    {
        _ = builder.ToTable("notification_contacts");

        _ = builder
            .HasKey(c => new { c.ResellerId, c.LicenseeId, c.BrandId, c.Type })
            .HasName("pk_notification_contacts");

        _ = builder
            .HasIndex(c => new { c.ResellerId, c.Type })
            .HasDatabaseName("ix_notification_contacts_reseller_id");
        _ = builder
            .HasIndex(c => new { c.LicenseeId, c.Type })
            .HasDatabaseName("ix_notification_contacts_licensee_id");
        _ = builder
            .HasIndex(c => new { c.BrandId, c.Type })
            .HasDatabaseName("ix_notification_contacts_brand_id");
        _ = builder
            .HasIndex(c => new { c.Type })
            .HasDatabaseName("ix_notification_contacts_typ");

        _ = builder.Property(c => c.ResellerId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("總公司識別碼");
        _ = builder.Property(c => c.LicenseeId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("公司識別碼");
        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("平台識別碼");
        _ = builder.Property(c => c.Type)
            .IsRequired()
            .HasDefaultValue(1)
            .HasComment("通知類型(信箱、Skype、Telegram)");
        _ = builder.Property(b => b.Contacts)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment(comment: "聯絡方式");
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("修改時間");
    }
}
