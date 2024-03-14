using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerPrimaryDetailMap : IEntityTypeConfiguration<GameWagerPrimaryDetail>
{
    void IEntityTypeConfiguration<GameWagerPrimaryDetail>.Configure(EntityTypeBuilder<GameWagerPrimaryDetail> builder)
    {
        _ = builder.ToTable("game_wager_primary_details");

        _ = builder
            .HasKey(c => new { c.ExternalCreatedOn, c.GameWagerPrimaryId })
            .HasName("pk_game_wager_primary_details");

        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.Id })
            .HasDatabaseName("ix_game_wager_primary_details_e_c_on_id");

        _ = builder.Property(c => c.Id)
            .IsRequired()
            .HasComment("識別碼");
        _ = builder.Property(c => c.GameWagerPrimaryId)
            .IsRequired()
            .HasComment("遊戲投注主要識別碼");
        _ = builder.Property(c => c.ExternalCreatedOn)
            .IsRequired()
            .HasComment("三方下注/創建時間");
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
