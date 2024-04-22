using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AgentDividendProductFeeMap : IEntityTypeConfiguration<AgentDividendProductFee>
{
    void IEntityTypeConfiguration<AgentDividendProductFee>.Configure(EntityTypeBuilder<AgentDividendProductFee> builder)
    {
        _ = builder.ToTable("agent_dividend_product_fees");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_agent_dividend_product_fees_id");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(b => b.AgentDividendId)
            .IsRequired();

        _ = builder.Property(e => e.GameType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.Percentage)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.WinLossAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(b => b.AgentDividendId)
            .HasDatabaseName("ix_agent_dividend_product_fees_agent_dividend_id");
    }
}
