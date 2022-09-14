using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerRebateMap : IEntityTypeConfiguration<PlayerRebate>
{
    void IEntityTypeConfiguration<PlayerRebate>.Configure(
        EntityTypeBuilder<PlayerRebate> builder)
    {
        _ = builder.ToTable("player_rebates");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_player_rebates_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.VipLiveDealerRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipSlotRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipCardGameRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipSportsRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipVirtualSportsRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VipLotteryRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryTurnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryRebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.RebateAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.ReportDate)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => new { b.BrandId, b.ReportDate })
            .HasDatabaseName("ix_player_rebates_brand_id_report_date");

        _ = builder.HasIndex(b => new { b.BrandId, b.ReportDate, b.PlayerCode })
            .HasDatabaseName("ix_player_rebates_brand_id_report_date_player_code");

        _ = builder.HasIndex(b => new { b.BrandId, b.ReportDate, b.AgentId })
            .HasDatabaseName("ix_player_rebates_brand_id_report_date_agent_id");
    }
}
