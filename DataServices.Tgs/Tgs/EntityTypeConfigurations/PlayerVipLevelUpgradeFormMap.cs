using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelUpgradeFormMap : IEntityTypeConfiguration<PlayerVipLevelUpgradeForm>
{
    void IEntityTypeConfiguration<PlayerVipLevelUpgradeForm>.Configure(
        EntityTypeBuilder<PlayerVipLevelUpgradeForm> builder)
    {
        _ = builder.ToTable("player_vip_level_upgrade_forms");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_upgrade_forms");
        _ = builder
            .HasIndex(c => new { c.CreatedOn })
            .HasDatabaseName("ix_player_vip_level_u_f_created_on");
        _ = builder
            .HasIndex(c => new { c.PlayerCode, c.VipLevel })
            .HasDatabaseName("ix_player_vip_level_u_f_player_code_vip_level");

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
        _ = builder.Property(b => b.VipLevel)
            .IsRequired()
            .HasComment("Vip等級");
        _ = builder.Property(b => b.AutoState)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("自動狀態(True:自動;False:手動)");
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
