using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerMarkerMap : IEntityTypeConfiguration<GameWagerMarker>
{
    void IEntityTypeConfiguration<GameWagerMarker>.Configure(EntityTypeBuilder<GameWagerMarker> builder)
    {
        _ = builder.ToTable("game_wager_markers");

        _ = builder
            .HasKey(c => new { c.Code })
            .HasName("pk_game_wager_markers");

        _ = builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(128)
            .HasComment("代碼");
        _ = builder.Property(c => c.Marker)
            .IsRequired()
            .HasComment("標記");
        _ = builder.Property(c => c.Expansions)
            .IsRequired()
            .HasColumnType(ColumnTypes.Jsonb)
            .HasDefaultValue("{}")
            .HasComment("擴充");
        _ = builder.Property(c => c.Directions)
            .IsRequired()
            .HasMaxLength(128)
            .HasComment(comment: "說明");
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
