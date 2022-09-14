using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerVipLevelAdjustRecordMap : IEntityTypeConfiguration<PlayerVipLevelAdjustRecord>
{
    void IEntityTypeConfiguration<PlayerVipLevelAdjustRecord>.Configure(EntityTypeBuilder<PlayerVipLevelAdjustRecord> builder)
    {
        _ = builder.ToTable("player_vip_level_adjust_records");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_vip_level_adjust_records");

        _ = builder.Property(b => b.Id)
            .IsRequired();
        _ = builder.Property(b => b.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();
        _ = builder.Property(b => b.OldVipId)
            .IsRequired();
        _ = builder.Property(b => b.NewVipId)
            .IsRequired();
        _ = builder.Property(b => b.OperatorId)
            .IsRequired();
        _ = builder.Property(b => b.Remark)
            .HasMaxLength(256)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => b.PlayerCode)
            .HasDatabaseName("ix_player_vip_level_adjust_records_player_code");

        _ = builder.HasIndex(b => b.CreatedOn)
.HasDatabaseName("ix_player_vip_level_adjust_records_created_on");
    }
}
