using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class PlayerVipLevelExpTurnoverRecordMap : IEntityTypeConfiguration<PlayerVipLevelExpTurnoverRecord>
{

    public void Configure(EntityTypeBuilder<PlayerVipLevelExpTurnoverRecord> builder)
    {
        _ = builder.ToTable("player_vip_level_exp_turnover_records");

        _ = builder
            .HasKey(c => new { c.SystemOn, c.Hash })
            .HasName("pk_player_vip_level_exp_turnover_records");

        _ = builder.Property(c => c.Hash)
            .IsRequired()
            .HasComment("雜湊");
        _ = builder.Property(c => c.PlayerCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("玩家代碼");
        _ = builder.Property(b => b.Type)
            .IsRequired()
            .HasComment("類型");
        _ = builder.Property(b => b.Sign)
            .IsRequired()
            .HasComment("符號(1:正號 -1:負號)");
        _ = builder.Property(b => b.Amount)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("金額");
        _ = builder.Property(b => b.Balance)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("餘額");
        _ = builder.Property(b => b.AdditionalData)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("附加資料");
        _ = builder.Property(b => b.Remark)
            .IsRequired()
            .HasDefaultValue("")
            .HasComment("備註");
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
        _ = builder.Property(c => c.Hash)
            .IsRequired()
            .HasMaxLength(256)
            .HasComment("Hash");
        _ = builder.Property(b => b.SystemOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("系統時間");
    }
}