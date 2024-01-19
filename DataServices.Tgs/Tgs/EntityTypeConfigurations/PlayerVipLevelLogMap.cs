using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelLogMap : IEntityTypeConfiguration<PlayerVipLevelLog>
{
    void IEntityTypeConfiguration<PlayerVipLevelLog>.Configure(EntityTypeBuilder<PlayerVipLevelLog> builder)
    {
        _ = builder.ToTable("player_vip_level_logs");

        _ = builder
            .HasKey(c => new { c.CreatedOn, c.Id })
            .HasName("pk_player_vip_level_logs");

        _ = builder
            .HasIndex(c => new { c.CreatedOn })
            .HasDatabaseName("ix_player_vip_level_logs_created_on");

        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.PlayerCode })
            .HasDatabaseName("ix_player_vip_level_logs_created_on_player_code");

        _ = builder.Property(c => c.Id)
            .IsRequired()
            .HasComment("識別碼");
        _ = builder.Property(c => c.PlayerCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("玩家代碼");
        _ = builder.Property(c => c.Type)
            .IsRequired()
            .HasDefaultValue(1)
            .HasComment("日誌類型");
        _ = builder.Property(b => b.Before)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("之前");
        _ = builder.Property(b => b.After)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("之後");
        _ = builder.Property(b => b.CreatedUserId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("創建使用者識別碼");
        _ = builder.Property(b => b.CreatedUsername)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue(string.Empty)
            .HasComment("創建使用者名稱");
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
        _ = builder.Property(b => b.Remark)
            .IsRequired()
            .HasDefaultValue("")
            .HasComment("備註");
    }
}
