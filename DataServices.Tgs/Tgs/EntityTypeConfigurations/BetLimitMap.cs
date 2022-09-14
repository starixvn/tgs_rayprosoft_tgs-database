using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BetLimitMap : IEntityTypeConfiguration<BetLimit>
{
    void IEntityTypeConfiguration<BetLimit>.Configure(EntityTypeBuilder<BetLimit> builder)
    {
        _ = builder.ToTable("bet_limits");

        _ = builder.HasKey(b => b.Id)
            .HasName("pk_bet_limits");

        _ = builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        _ = builder.Property(b => b.CurrencyCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(b => b.MinBet)
            .IsRequired();

        _ = builder.Property(b => b.MaxBet)
            .IsRequired();

        _ = builder.Property(b => b.MaxBetPerMatch)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();

        _ = builder.Property(b => b.UpdatedOn)
            .IsRequired();

        _ = builder.Property(b => b.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(b => b.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.HasOne(e => e.Currency)
            .WithMany(e => e.BetLimits)
            .HasForeignKey(e => e.CurrencyCode)
            .HasConstraintName("fk_bet_limits_currencies_currency_code");

        _ = builder.HasIndex(e => e.CurrencyCode)
            .HasDatabaseName("ix_bet_limits_currency_code");
    }
}
