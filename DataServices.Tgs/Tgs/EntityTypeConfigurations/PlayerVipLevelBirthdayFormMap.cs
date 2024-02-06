using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelBirthdayFormMap : IEntityTypeConfiguration<PlayerVipLevelBirthdayForm>
{
    void IEntityTypeConfiguration<PlayerVipLevelBirthdayForm>.Configure(
        EntityTypeBuilder<PlayerVipLevelBirthdayForm> builder)
    {
        _ = builder.ToTable("player_vip_level_birthday_forms");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_birthday_forms");
        _ = builder
            .HasIndex(c => new { c.CreatedOn })
            .HasDatabaseName("ix_player_vip_level_b_f_created_on");
        _ = builder
            .HasIndex(c => new { c.PlayerCode, c.Birthday })
            .HasDatabaseName("ix_player_vip_level_b_f_player_code_birthday");

        _ = builder.Property(b => b.Id)
            .IsRequired()
            .HasComment("識別碼");
        _ = builder.Property(b => b.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");
        _ = builder.Property(b => b.PlayerCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("玩家代碼");
        _ = builder.Property(b => b.Level)
            .IsRequired()
            .HasComment("等級");
        _ = builder.Property(b => b.Birthday)
            .IsRequired()
            .HasComment("生日");
        _ = builder.Property(b => b.State)
            .IsRequired()
            .HasComment("狀態");
        _ = builder.Property(b => b.Amount)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasComment("金額");
        _ = builder.Property(b => b.ActualAmount)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasComment("實際金額");
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
        _ = builder.Property(b => b.CreatedUserId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("創建使用者識別碼");
        _ = builder.Property(b => b.CreatedUsername)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue(string.Empty)
            .HasComment("創建使用者名稱");
        _ = builder.Property(b => b.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("更新時間");
        _ = builder.Property(b => b.UpdatedUserId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("更新使用者識別碼");
        _ = builder.Property(b => b.UpdatedUsername)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue(string.Empty)
            .HasComment("更新使用者名稱");
        _ = builder.Property(b => b.SnapshotVipLevel)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("Snapshot Vip Level");
        _ = builder.Property(b => b.Remark)
            .IsRequired()
            .HasDefaultValue("")
            .HasComment("備註");
    }
}
