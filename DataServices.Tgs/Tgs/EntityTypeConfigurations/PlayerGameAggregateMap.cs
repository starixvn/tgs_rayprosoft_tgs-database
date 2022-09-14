using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerGameTypeAggregateMap : IEntityTypeConfiguration<PlayerGameAggregate>
{
    void IEntityTypeConfiguration<PlayerGameAggregate>.Configure(
        EntityTypeBuilder<PlayerGameAggregate> builder)
    {
        _ = builder.ToTable("player_game_rebate_aggregates", Consts.ReportSchema);

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_game_rebate_aggregates_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.GameType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.BetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.ValidBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.OriginalTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.Turnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.WinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipLevel)
            .IsRequired(false);

        _ = builder.Property(c => c.VipLiveDealerRebatePercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipSlotRebatePercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipCardGameRebatePercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipSportsRebatePercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipVirtualSportsRebatePercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipLotteryRebatePercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.ReportDate)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => new
        {
            b.ReportDate,
            b.BrandId,
            b.AgentId,
            b.PlayerCode
        })
            .HasDatabaseName("ix_player_game_rebate_aggregates_multiple_keys");
    }
}
