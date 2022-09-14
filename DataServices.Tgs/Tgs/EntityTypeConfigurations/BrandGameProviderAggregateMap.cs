using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGameProviderAggregateMap : IEntityTypeConfiguration<BrandGameProviderAggregate>
{
    void IEntityTypeConfiguration<BrandGameProviderAggregate>.Configure(
        EntityTypeBuilder<BrandGameProviderAggregate> builder)
    {
        _ = builder.ToTable("brand_game_provider_aggregates", Consts.ReportSchema);

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_brand_game_provider_aggregate_id");

        _ = builder.Property(c => c.AuditLogId)
            .IsRequired();

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.GameProviderId)
            .IsRequired();

        _ = builder.Property(c => c.GameType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.CurrencyCode)
            .IsRequired();

        _ = builder.Property(c => c.BetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.ValidBetAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.Turnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.WinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SettleAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Commission)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.ReportDate)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(c => c.AuditLogId)
            .HasDatabaseName("ix_brand_game_provider_aggregate_audit_log_id");

        _ = builder.HasIndex(c => new
        {
            c.ReportDate,
            c.BrandId,
            c.GameProviderId
        })
            .HasDatabaseName("ix_brand_game_provider_aggregate_multiple_keys");
    }
}
