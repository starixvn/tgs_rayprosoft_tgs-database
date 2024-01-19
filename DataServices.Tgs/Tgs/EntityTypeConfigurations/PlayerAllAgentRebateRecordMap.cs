using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerAllAgentRebateRecordMap : IEntityTypeConfiguration<PlayerAllAgentRebateRecord>
{
    void IEntityTypeConfiguration<PlayerAllAgentRebateRecord>.Configure(
        EntityTypeBuilder<PlayerAllAgentRebateRecord> builder)
    {
        _ = builder.ToTable("player_all_agent_rebate_records");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_all_agent_rebate_records_id");

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(b => b.AllAgentGameType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.AllAgentRebateType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.ConditionAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.RebatePercentage)
            .HasPrecision(9, 6)
            .IsRequired();

        _ = builder.Property(c => c.ActualConditionAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.RebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.SettleDate)
            .IsRequired();

        _ = builder.Property(b => b.From)
            .HasDefaultValueSql("now()")
            .IsRequired();

        _ = builder.Property(b => b.To)
            .HasDefaultValueSql("now()")
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => new
        {
            b.SettleDate,
            b.BrandId,
            b.PlayerCode
        })
            .HasDatabaseName("ix_player_all_agent_rebate_records_settle_date_brand_id_player_code");
    }
}
