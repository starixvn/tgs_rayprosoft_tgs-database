using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class VipLevelSnapshotMap : BaseConfiguration, IEntityTypeConfiguration<VipLevelSnapshot>
{
    void IEntityTypeConfiguration<VipLevelSnapshot>.Configure(EntityTypeBuilder<VipLevelSnapshot> builder)
    {
        _ = builder.ToTable("vip_level_snapshots");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_vip_level_snapshots");

        _ = builder
            .HasIndex(c => new { c.BrandId })
            .HasDatabaseName("ix_vip_level_snapshots_brand_id");

        _ = builder.Property(c => c.Id)
            .IsRequired()
            .HasComment("識別碼");

        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");

        _ = builder.Property(b => b.Data)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasComment("資料");

        _ = builder.Property(c => c.EffectiveOn)
            .IsRequired()
            .HasComment("生效時間");

        _ = builder.Property(c => c.SnapshotOn)
            .IsRequired()
            .HasComment("快照時間");

        _ = builder.Property(c => c.SnapshotUserId)
            .IsRequired()
            .HasComment("快照使用者識別碼");

        _ = builder.Property(c => c.SnapshotUsername)
            .IsRequired()
            .HasMaxLength(50)
            .HasComment("快照使用者名稱");
    }
}
