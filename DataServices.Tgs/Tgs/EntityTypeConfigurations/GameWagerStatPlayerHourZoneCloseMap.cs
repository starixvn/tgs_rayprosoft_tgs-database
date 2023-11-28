using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerStatPlayerHourZoneCloseMap : IEntityTypeConfiguration<GameWagerStatPlayerHourZoneClose>
{
    void IEntityTypeConfiguration<GameWagerStatPlayerHourZoneClose>.Configure(EntityTypeBuilder<GameWagerStatPlayerHourZoneClose> builder)
    {
        _ = builder.ToTable("game_wager_stat_player_hour_zone_closes");

        _ = builder
            .HasKey(c => new { c.StatOn, c.ResellerId, c.LicenseeId, c.BrandId, c.PlayerCode, c.GameProviderId })
            .HasName("pk_game_wager_stat_player_hour_zone_closes");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.PlayerCode })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_player_code");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.BrandId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_brand_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.GameProviderId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_game_provider_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.LicenseeId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_licensee_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.ResellerId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_reseller_id");
        _ = builder
            .HasIndex(c => new { c.StatOn })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_stat_on");

        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.PlayerCode })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_player_code");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.BrandId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_brand_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.GameProviderId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_game_provider_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.LicenseeId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_licensee_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.ResellerId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_reseller_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_stat_day_on");

        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.StatHourOn, c.PlayerCode })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_h_player_code");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.StatHourOn, c.BrandId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_h_brand_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.StatHourOn, c.GameProviderId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_h_game_provider_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.StatHourOn, c.LicenseeId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_h_licensee_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.StatHourOn, c.ResellerId })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_h_reseller_id");
        _ = builder
            .HasIndex(c => new { c.StatOn, c.StatDayOn, c.StatHourOn })
            .HasDatabaseName("ix_game_wager_stat_player_h_z_c_d_h_stat_hour_on");

        _ = builder.Property(c => c.ResellerId)
            .IsRequired()
            .HasComment("公司識別碼");
        _ = builder.Property(c => c.LicenseeId)
            .IsRequired()
            .HasComment("分公司識別碼");
        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");
        _ = builder.Property(c => c.PlayerCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("玩家代碼");
        _ = builder.Property(c => c.GameProviderId)
            .IsRequired()
            .HasComment("遊戲供應商識別碼");
        _ = builder.Property(c => c.StatOn)
            .IsRequired()
            .HasComment("統計時間");
        _ = builder.Property(c => c.StatDayOn)
            .IsRequired()
            .HasComment("統計日時間");
        _ = builder.Property(c => c.StatHourOn)
            .IsRequired()
            .HasComment("統計小時時間");
        _ = builder.Property(b => b.Count)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("筆數");
        _ = builder.Property(b => b.Bet)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("下注");
        _ = builder.Property(b => b.ValidBet)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("實際/有效下注");
        _ = builder.Property(b => b.Settle)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("結算(包含本金)");
        _ = builder.Property(b => b.Commission)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("傭金");
        _ = builder.Property(b => b.Turnover)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("有效投注");
        _ = builder.Property(b => b.WinLoss)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("玩家損益/淨利");
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
