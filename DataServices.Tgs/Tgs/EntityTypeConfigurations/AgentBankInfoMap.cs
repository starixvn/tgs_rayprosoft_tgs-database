using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentBankInfoMap : IEntityTypeConfiguration<AgentBankInfo>
{
    public void Configure(EntityTypeBuilder<AgentBankInfo> builder)
    {
        _ = builder.ToTable("agent_bank_infos");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_agent_bank_infos");

        _ = builder.Property(c => c.AgentId)
            .IsRequired();

        _ = builder.Property(c => c.BrandId)
            .IsRequired();

        _ = builder.Property(c => c.PaymentChannelId)
            .IsRequired();

        _ = builder.Property(c => c.BankType)
            .IsRequired();

        _ = builder.Property(c => c.Detail)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder.HasIndex(c => c.AgentId)
            .HasDatabaseName("ix_agent_bank_infos_agent_id");

        _ = builder.HasOne(c => c.Brand)
            .WithMany()
            .HasConstraintName("fk_agent_bank_infos_brands_brand_id");

        _ = builder.HasIndex(c => c.BrandId)
            .HasDatabaseName("ix_agent_bank_infos_brand_id");

        _ = builder.HasOne(c => c.PaymentChannel)
            .WithMany()
            .HasConstraintName("fk_agent_bank_infos_payment_channels_payment_channel_id");

        _ = builder.HasIndex(c => c.PaymentChannelId)
            .HasDatabaseName("ix_agent_bank_infos_payment_channel_id");
    }
}
