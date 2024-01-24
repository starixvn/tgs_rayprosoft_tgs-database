using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class PlayerVipLevelExpMap : IEntityTypeConfiguration<PlayerVipLevelExp>
{

    public void Configure(EntityTypeBuilder<PlayerVipLevelExp> builder)
    {
        _ = builder.ToTable("player_vip_level_exps");

        _ = builder
            .HasKey(c => new { c.PlayerCode })
            .HasName("pk_player_vip_level_exps");

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("玩家代碼");

        _ = builder.Property(b => b.AccumDepositId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("累積存款識別碼");

        _ = builder.Property(b => b.AccumDeposit)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("累積存款");

        _ = builder.Property(b => b.AccumTurnoverId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("累積有效投注識別碼");

        _ = builder.Property(b => b.AccumTurnover)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("累積有效投注");
    }
}
