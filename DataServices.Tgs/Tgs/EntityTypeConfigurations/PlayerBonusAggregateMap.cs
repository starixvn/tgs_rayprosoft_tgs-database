using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBonusAggregateMap : IEntityTypeConfiguration<PlayerBonusAggregate>
{
    void IEntityTypeConfiguration<PlayerBonusAggregate>.Configure(EntityTypeBuilder<PlayerBonusAggregate> builder)
    {
        _ = builder.ToTable("player_bonus_aggregates", Consts.ReportSchema);

        _ = builder.HasKey(b => new
        {
            b.PlayerCode,
            b.Hour,
            b.Minute,
            b.ReportDate
        })
            .HasName("pk_player_bonus_aggregates_id");

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(b => b.RebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.PromotionAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.UpgradeAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.SeasonAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.BirthdayAmount)
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
            .HasDatabaseName("ix_player_bonus_aggregates_multiple_keys")
#if NET8_0_OR_GREATER
            .IsDescending(
                true,
                false,
                false,
                false
            );
#else
            .HasSortOrder(new[]
            {
                SortOrder.Descending,
                SortOrder.Ascending,
                SortOrder.Ascending,
                SortOrder.Ascending
            });
#endif
    }
}
