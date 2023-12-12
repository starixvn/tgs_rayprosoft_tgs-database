using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TGS.Core.DataServices.Tgs.Models;
using System.Text.Json;
using System.Xml.Linq;
using System.Text.Json.Nodes;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGameCreditSuspSettingMap : IEntityTypeConfiguration<BrandGameCreditSuspSetting>
{
    void IEntityTypeConfiguration<BrandGameCreditSuspSetting>.Configure(EntityTypeBuilder<BrandGameCreditSuspSetting> builder)
    {
        _ = builder.ToTable("brand_game_credit_susp_settings");

        _ = builder
            .HasKey(c => new { c.BrandId })
            .HasName("pk_brand_game_credit_susp_settings");

        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");
        _ = builder.Property(b => b.LowRisk)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(60)
            .HasComment("低度風險");
        _ = builder.Property(b => b.LowNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{}"))
            .HasComment("低度風險通知");
        _ = builder.Property(b => b.ModerateRisk)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(80)
            .HasComment("中度風險");
        _ = builder.Property(b => b.ModerateNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{}"))
            .HasComment("中度風險通知");
        _ = builder.Property(b => b.HighRisk)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(95)
            .HasComment("高度風險");
        _ = builder.Property(b => b.HighNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{}"))
            .HasComment("高度風險通知");
        _ = builder.Property(b => b.Credit)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0)
            .HasComment("信用額度");
        _ = builder.Property(b => b.CreditNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{}"))
            .HasComment("信用額度通知");
        _ = builder.Property(b => b.ManualNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{}"))
            .HasComment("手動通知");
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
