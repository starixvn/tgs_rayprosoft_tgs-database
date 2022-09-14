using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class RoundAggregateMap : IEntityTypeConfiguration<RoundAggregate>
{
    void IEntityTypeConfiguration<RoundAggregate>.Configure(EntityTypeBuilder<RoundAggregate> builder)
    {
        _ = builder.ToTable("round_aggregates", Consts.ReportSchema);

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_round_aggregate_id");

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

        _ = builder.HasIndex(c => new { c.PlayerCode })
            .HasDatabaseName("ix_round_aggregate_player_code");

        _ = builder.HasIndex(c => new
        {
            c.ReportDate,
            c.Hour,
            c.Minute
        })
            .HasDatabaseName("ix_round_aggregate_multiple_keys");
    }
}
