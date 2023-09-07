using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerDetailMap : IEntityTypeConfiguration<GameWagerDetail>
{
    void IEntityTypeConfiguration<GameWagerDetail>.Configure(EntityTypeBuilder<GameWagerDetail> builder)
    {
        _ = builder.ToTable("game_wager_details");

        _ = builder
            .HasKey(c => new { c.CreatedOn, c.WagerId })
            .HasName("pk_game_wager_details");
        _ = builder
            .HasIndex(c => new { c.WagerId })
            .HasDatabaseName("ix_game_wager_details_wager_id");

        _ = builder.Property(c => c.WagerId)
            .IsRequired()
            .HasComment("投注識別碼");

        _ = builder.Property(c => c.AdditionalData)
            .IsRequired()
            .HasColumnType(ColumnTypes.Jsonb)
            .HasDefaultValue("{}")
            .HasComment("附加數據");
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
