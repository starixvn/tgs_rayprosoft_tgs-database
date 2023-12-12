using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TGS.Core.DataServices.Tgs.Models;
using System.Text.Json;

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
            .HasDefaultValue(JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}"))
            .HasComment("低度風險通知");
        _ = builder.Property(b => b.ModerateRisk)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(80)
            .HasComment("中度風險");
        _ = builder.Property(b => b.ModerateNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 緊急加值通知 Warning: Balance too low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度嚴重不足，所有遊戲暫時不可進入；為避免影響平台正常運營，請立即聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a higher balance usage, and the access to all games will be temporarily suspended. To maintain the stability of your site, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}"))
            .HasComment("中度風險通知");
        _ = builder.Property(b => b.HighRisk)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(95)
            .HasComment("高度風險");
        _ = builder.Property(b => b.HighNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 平台已停用，請立即加值 Notice of Suspension\",\"Content\":\"貴司您好，\\r\\n由於您的平台剩餘額度已低於限制，平台及所有遊戲暫時不可進入；請立即聯繫貴司對應商務進行加值，並由專人協助您恢復平台運行，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site has been temporarily suspended due to a balance usage that has exceeded the limit. To recover the full access of platform and all games, we kindly recommend reaching out to your designated business contact for a top-up immediately. Thank you.\"}"))
            .HasComment("高度風險通知");
        _ = builder.Property(b => b.Credit)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0)
            .HasComment("信用額度");
        _ = builder.Property(b => b.CreditNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}"))
            .HasComment("信用額度通知");
        _ = builder.Property(b => b.ManualNotification)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValue(JsonDocument.Parse("{\"Subject\":\"[Licensee][Brand] 加值通知 Warning: Balance low\",\"Content\":\"敬愛的夥伴您好，\\r\\n您的平台目前剩餘額度不足，為避免影響會員遊戲體驗，請盡速聯繫貴司對應商務進行加值，謝謝您。\\r\\nDear Partner,\\r\\nWe wanted to inform you that your site currently has reached a high balance usage. To maintain the stability and quality of your gaming experience, we kindly recommend reaching out to your designated business contact for a top-up. Thank you.\"}"))
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
