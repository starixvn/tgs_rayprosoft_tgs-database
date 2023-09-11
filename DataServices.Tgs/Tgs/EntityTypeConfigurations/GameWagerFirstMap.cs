using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerFirstMap : IEntityTypeConfiguration<GameWagerFirst>
{
    void IEntityTypeConfiguration<GameWagerFirst>.Configure(EntityTypeBuilder<GameWagerFirst> builder)
    {
        var tableName = "game_wager_firsts";
        _ = builder.ToTable(tableName);

        _ = builder
            .HasKey(c => new { c.FirstOn, c.GameProviderId, c.GameId, c.WalletId, c.ExternalWagerId })
            .HasName($"pk_{tableName}");
        _ = builder
            .HasIndex(c => new { c.GameProviderId, c.GameId, c.WalletId, c.ExternalWagerId })
            .HasDatabaseName($"ix_{tableName}");
        _ = builder
            .HasIndex(c => new { c.WagerId })
            .HasDatabaseName($"ix_{tableName}_wager_id");
        _ = builder
            .HasIndex(c => new { c.ExternalRoundId })
            .HasDatabaseName($"ix_{tableName}_external_round_id");
        _ = builder
            .HasIndex(c => new { c.ExternalWagerId })
            .HasDatabaseName($"ix_{tableName}_external_wager_id");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.GameId })
            .HasDatabaseName($"ix_{tableName}_first_on_game_id");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.BrandId })
            .HasDatabaseName($"ix_{tableName}_first_on_brand_id");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.WagerId })
            .HasDatabaseName($"ix_{tableName}_first_on_wager_id");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.ExternalRoundId })
            .HasDatabaseName($"ix_{tableName}_first_on_external_round_id");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.ExternalWagerId })
            .HasDatabaseName($"ix_{tableName}_first_on_external_wager_id");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.BrandId, c.PlayerCode })
            .HasDatabaseName($"ix_{tableName}_first_on_brand_id_player_code");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.PlayerCode })
            .HasDatabaseName($"ix_{tableName}_first_on_player_code");
        _ = builder
            .HasIndex(c => new { c.FirstOn, c.GameProviderId })
            .HasDatabaseName($"ix_{tableName}_first_on_game_provider_id");

        _ = builder.Property(c => c.WagerId)
            .IsRequired()
            .HasComment("投注識別碼");
        _ = builder.Property(c => c.GameProviderId)
            .IsRequired()
            .HasComment("遊戲供應商識別碼");
        _ = builder.Property(c => c.GameProviderConfigurationId)
            .IsRequired()
            .HasComment("遊戲供應商設定識別碼");
        _ = builder.Property(c => c.GameId)
            .IsRequired()
            .HasComment("遊戲識別碼");
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
            .HasComment("玩家代碼");
        _ = builder.Property(c => c.CurrencyCode)
            .IsRequired()
            .HasMaxLength(16)
            .HasComment("貨幣代碼");
        _ = builder.Property(c => c.WalletId)
            .IsRequired()
            .HasComment("錢包識別碼");
        _ = builder.Property(c => c.WagerState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("投注狀態");
        _ = builder.Property(c => c.WagerType)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("投注類型");
        _ = builder.Property(c => c.ClosedState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("關閉狀態");
        _ = builder.Property(c => c.VoidState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("作廢狀態");
        _ = builder.Property(c => c.CancelState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("取消狀態");
        _ = builder.Property(c => c.FreeGameState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("免費遊戲狀態");
        _ = builder.Property(c => c.GambleState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("博取遊戲狀態");
        _ = builder.Property(c => c.CashoutState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("兌現狀態");
        _ = builder.Property(c => c.ResettleState)
            .IsRequired()
            .HasDefaultValue(0)
            .HasComment("重新結算狀態");
        _ = builder.Property(c => c.ExternalRoundId)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("三方局/回合識別碼");
        _ = builder.Property(c => c.ExternalWagerId)
            .IsRequired()
            .HasMaxLength(255)
            .HasComment("三方投注識別碼");
        _ = builder.Property(c => c.ExternalCreatedOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方下注/創建時間");
        _ = builder.Property(c => c.ExternalClosedOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方結算/結束時間");
        _ = builder.Property(c => c.ExternalPayoffOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方派彩時間");
        _ = builder.Property(c => c.ExternalResettleOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("三方重新結算時間");
        _ = builder.Property(b => b.CurrencyRatio)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("貨幣比例");
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
        _ = builder.Property(c => c.ClosedOn)
            .IsRequired()
            .HasDefaultValueSql("'1970-01-01 00:00:00+00'::timestamp with time zone")
            .HasComment("結束時間");
        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("修改時間");
        _ = builder.Property(c => c.FirstOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("首筆時間");
    }
}
