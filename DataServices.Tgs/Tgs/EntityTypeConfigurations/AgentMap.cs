using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentMap : IEntityTypeConfiguration<Agent>
{
    void IEntityTypeConfiguration<Agent>.Configure(EntityTypeBuilder<Agent> builder)
    {
        _ = builder.ToTable("agents");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agents");

        _ = builder.Property(c => c.Username)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.RealName)
            .HasMaxLength(32);

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Type)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.InvitationCode)
            .HasMaxLength(6)
            .IsRequired();

        _ = builder.Property(c => c.Password)
            .IsRequired();

        _ = builder.Property(c => c.Salt)
            .IsRequired();

        _ = builder.Property(c => c.WithdrawPassword)
            .IsRequired();

        _ = builder.Property(c => c.WithdrawSalt)
            .IsRequired();

        _ = builder.Property(c => c.RegisteredOn)
            .IsRequired();

        _ = builder.Property(c => c.Phone)
            .HasMaxLength(32);

        _ = builder.Property(c => c.Email)
            .HasMaxLength(64);

        _ = builder.Property(c => c.QQ)
            .HasMaxLength(64);

        _ = builder.Property(c => c.Wechat)
            .HasMaxLength(64);

        _ = builder.Property(c => c.CommissionPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.DividendPercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LiveDealerRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SlotRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.LotteryRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CardGameRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.SportsRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.VirtualSportsRebatePercentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Path)
            .HasColumnType("ltree")
            .IsRequired();

        _ = builder.Property(p => p.SnapshotEventId);

        _ = builder.HasOne(p => p.Brand)
            .WithMany()
            .HasForeignKey(p => p.BrandId)
            .HasConstraintName("fk_agents_brands_brand_id");

        _ = builder.HasOne(p => p.ParentAgent)
            .WithMany(p => p.SubAgents)
            .HasForeignKey(p => p.ParentAgentId)
            .HasConstraintName("fk_agents_parent_agent_id")
            .IsRequired(false);

        _ = builder.HasMany(p => p.AgentDividendConditions)
            .WithOne(p => p.Agent)
            .HasForeignKey(p => p.AgentId)
            .HasConstraintName("fk_agents_dividend_conditions_agent_id");

        _ = builder.HasIndex(c => c.BrandId)
            .HasDatabaseName("ix_agents_brand_id");

        _ = builder.HasIndex(c => c.Path)
            .HasMethod("gist")
            .HasDatabaseName("ix_agents_gist_path");
    }
}
