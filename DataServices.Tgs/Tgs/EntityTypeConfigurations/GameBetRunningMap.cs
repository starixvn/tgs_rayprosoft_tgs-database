using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;
using static Dapper.SqlMapper;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameBetRunningMap : IEntityTypeConfiguration<GameBetRunning>
{
    void IEntityTypeConfiguration<GameBetRunning>.Configure(EntityTypeBuilder<GameBetRunning> builder)
    {
        _ = builder.ToTable("game_bet_runnings");

        _ = builder.HasKey(e => e.GameBetMajorId).HasName("pk_game_bet_runnings");

        _ = builder.HasIndex(e => new { e.GameProviderId, e.GameId, e.WalletId, e.ExternalBetId }, "uix_game_bet_runnings").IsUnique();

        _ = builder.Property(e => e.GameBetMajorId)
            .ValueGeneratedNever()
            .HasComment("遊戲投注主要識別碼")
            .HasColumnName("game_bet_major_id");
        _ = builder.Property(e => e.AdditionalData)
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("附加數據")
            .HasColumnType("jsonb")
            .HasColumnName("additional_data");
        _ = builder.Property(e => e.Bet)
            .HasPrecision(18, 6)
            .HasComment("下注")
            .HasColumnName("bet");
        _ = builder.Property(e => e.BetType)
            .HasDefaultValue(0)
            .HasComment("注單類型")
            .HasColumnName("bet_type");
        _ = builder.Property(e => e.BrandId)
            .HasComment("平台識別碼")
            .HasColumnName("brand_id");
        _ = builder.Property(e => e.CreatedOn)
            .HasComment("創建時間")
            .HasColumnName("created_on");
        _ = builder.Property(e => e.CurrencyCode)
            .HasMaxLength(16)
            .HasComment("貨幣代碼")
            .HasColumnName("currency_code");
        _ = builder.Property(e => e.CurrencyRatio)
            .HasPrecision(18, 6)
            .HasComment("貨幣比例")
            .HasColumnName("currency_ratio");
        _ = builder.Property(e => e.ExtendedData)
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("擴充數據")
            .HasColumnType("jsonb")
            .HasColumnName("extended_data");
        _ = builder.Property(e => e.ExternalBetId)
            .HasMaxLength(255)
            .HasComment("三方投注單別碼")
            .HasColumnName("external_bet_id");
        _ = builder.Property(e => e.ExternalCreatedOn)
            .HasComment("三方下注/創建時間")
            .HasColumnName("external_created_on");
        _ = builder.Property(e => e.ExternalRoundId)
            .HasMaxLength(255)
            .HasComment("三方局/回合識別碼")
            .HasColumnName("external_round_id");
        _ = builder.Property(e => e.GameId)
            .HasComment("遊戲識別碼")
            .HasColumnName("game_id");
        _ = builder.Property(e => e.GameProviderConfigurationId)
            .HasComment("遊戲供應商設定識別碼")
            .HasColumnName("game_provider_configuration_id");
        _ = builder.Property(e => e.GameProviderId)
            .HasComment("遊戲供應商識別碼")
            .HasColumnName("game_provider_id");
        _ = builder.Property(e => e.LicenseeId)
            .HasComment("分公司識別碼")
            .HasColumnName("licensee_id");
        _ = builder.Property(e => e.PlayerCode)
            .HasMaxLength(16)
            .HasComment("玩家代碼")
            .HasColumnName("player_code");
        _ = builder.Property(e => e.ResellerId)
            .HasComment("公司識別碼")
            .HasColumnName("reseller_id");
        _ = builder.Property(e => e.UpdatedOn)
            .HasComment("修改時間")
            .HasColumnName("updated_on");
        _ = builder.Property(e => e.ValidBet)
            .HasPrecision(18, 6)
            .HasComment("實際/有效下注")
            .HasColumnName("valid_bet");
        _ = builder.Property(e => e.WalletId)
            .HasComment("錢包識別碼")
            .HasColumnName("wallet_id");
    }
}
