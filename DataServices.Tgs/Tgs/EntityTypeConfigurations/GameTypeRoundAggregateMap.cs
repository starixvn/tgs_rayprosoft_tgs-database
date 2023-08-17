using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameTypeRoundAggregateMap : IEntityTypeConfiguration<GameTypeRoundAggregate>
{
    void IEntityTypeConfiguration<GameTypeRoundAggregate>.Configure(EntityTypeBuilder<GameTypeRoundAggregate> builder)
    {
        _ = builder.ToTable("game_type_round_aggregates", Consts.ReportSchema);

        _ = builder.HasKey(c => new { c.BrandId, c.AgentId, c.PlayerCode, c.From, c.To })
            .HasName("pk_game_type_round_aggregate_id");

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.GameType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.BetAmount)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.ValidBetAmount)
            .HasPrecision(18, 6);

        _ = builder.Property(b => b.OriginalTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Turnover)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.WinLoss)
            .HasPrecision(18, 6);
    }
}
