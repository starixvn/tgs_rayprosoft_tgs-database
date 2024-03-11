using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameWagerPrimaryMap : IEntityTypeConfiguration<GameWagerPrimary>
{
    void IEntityTypeConfiguration<GameWagerPrimary>.Configure(EntityTypeBuilder<GameWagerPrimary> builder)
    {
        _ = builder.ToTable("game_wager_primaries");

        _ = builder
            .HasKey(c => new { c.ExternalCreatedOn, c.GameProviderId, c.GameId, c.WalletId, c.ExternalWagerId })
            .HasName("pk_game_wager_primaries");

        _ = builder
            .HasIndex(c => new { c.GameProviderId, c.GameId, c.WalletId, c.ExternalWagerId })
            .HasDatabaseName("ix_game_wager_primaries");

        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.Id })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.GameProviderId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_game_provider_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.GameId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_game_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.ResellerId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_reseller_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.LicenseeId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_licensee_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.BrandId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_brand_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.PlayerCode })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_player_code");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.ExternalRoundId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_external_round_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.ExternalWagerId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_external_wager_id");

        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.Id })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.GameProviderId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_game_provider_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.GameId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_game_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.ResellerId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_reseller_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.LicenseeId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_licensee_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.BrandId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_brand_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.PlayerCode })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_player_code");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.ExternalRoundId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_external_round_id");
        _ = builder
            .HasIndex(c => new { c.ExternalCreatedOn, c.CreatedOn, c.ExternalWagerId })
            .HasDatabaseName("ix_game_wager_primaries_e_c_on_c_on_external_wager_id");

        _ = builder.Property(c => c.Id)
            .IsRequired()
            .HasComment("識別碼");
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
            .HasComment("三方下注/創建時間");
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
    }
}
