using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerMap : IEntityTypeConfiguration<Player>
{
    void IEntityTypeConfiguration<Player>.Configure(EntityTypeBuilder<Player> builder)
    {
        _ = builder.ToTable("players");

        _ = builder.HasKey(bc => bc.PlayerCode)
            .HasName("pk_player_code");

        _ = builder.Property(c => c.IdNumber)
            .HasMaxLength(50);

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.Username)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.RealName)
            .HasMaxLength(256);

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Type)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Password)
            .IsRequired();

        _ = builder.Property(c => c.Salt)
            .IsRequired();

        _ = builder.Property(c => c.WithdrawPassword)
            .IsRequired();

        _ = builder.Property(c => c.WithdrawSalt)
            .IsRequired();

        _ = builder.Property(c => c.BetLimitId)
            .IsRequired();

        _ = builder.Property(c => c.DefaultWalletCurrencyCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.RegisteredOn);

        _ = builder.Property(c => c.LastActiveOn)
            .IsRequired();

        _ = builder.Property(c => c.VipId)
            .IsRequired(false);

        _ = builder.Property(c => c.AreaCode)
            .HasMaxLength(10);

        _ = builder.Property(c => c.Phone)
            .HasMaxLength(32);

        _ = builder.Property(c => c.Email)
            .HasMaxLength(64);

        _ = builder.Property(c => c.QQ)
            .HasMaxLength(64);

        _ = builder.Property(c => c.Wechat)
            .HasMaxLength(64);

        _ = builder.Property(p => p.Birthdate)
            .HasColumnType("Date");

        _ = builder.Property(p => p.Birthday)
            .HasMaxLength(4)
            .HasComputedColumnSql("lpad(extract('month' from birthdate)::text,2,'0') || lpad(extract('day' from birthdate)::text,2,'0')", stored: true);

        _ = builder.Property(p => p.Remark);

        _ = builder.Property(c => c.AccumulatedDeposit)
            .HasPrecision(18, 6)
            .HasDefaultValue(0)
            .IsRequired();

        _ = builder.Property(p => p.FirstDepositOn);

        _ = builder.Property(p => p.FirstPromotionOn);

        _ = builder.Property(p => p.SnapshotEventId);

        _ = builder.HasOne(p => p.Brand)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.BrandId)
            .HasConstraintName("fk_players_brands_brand_id");

        _ = builder.HasOne(p => p.Agent)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.AgentId)
            .HasConstraintName("fk_players_agents_agent_id");

        _ = builder.HasOne(p => p.Vip)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.VipId)
            .HasConstraintName("fk_players_vip_levels_vip_id");

        _ = builder.HasIndex(p => p.VipId)
            .HasDatabaseName("ix_players_vip_id");

        _ = builder.HasOne(p => p.BetLimit)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.BetLimitId)
            .HasConstraintName("fk_players_bet_limits_bet_limit_id")
            .OnDelete(DeleteBehavior.Restrict);

        _ = builder.HasIndex(p => p.BetLimitId)
            .HasDatabaseName("ix_players_bet_limit_id");

        _ = builder.HasIndex(p => new
        {
            p.BrandId,
            p.AreaCode,
            p.Phone
        })
            .IsUnique()
            .HasDatabaseName("ux_players_brand_phone");
    }
}
