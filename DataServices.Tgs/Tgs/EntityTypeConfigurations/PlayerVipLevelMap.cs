using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelMap : IEntityTypeConfiguration<PlayerVipLevel>
{
    void IEntityTypeConfiguration<PlayerVipLevel>.Configure(EntityTypeBuilder<PlayerVipLevel> builder)
    {
        _ = builder.ToTable("player_vip_levels");

        _ = builder
            .HasKey(c => new { c.PlayerCode })
            .HasName("pk_player_vip_levels");

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("玩家代碼");
        _ = builder.Property(c => c.VipLevelId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("VipLevel識別碼");
        _ = builder.Property(b => b.VipLevel)
            .IsRequired()
            .HasDefaultValue(1)
            .HasComment("VipLevel等級");
        _ = builder.Property(b => b.AutoState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("自動狀態(0:啟用 1:停用)");
    }
}
