using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlatformPayRecordMap : BaseConfiguration, IEntityTypeConfiguration<PlatformPayRecord>
{
    void IEntityTypeConfiguration<PlatformPayRecord>.Configure(EntityTypeBuilder<PlatformPayRecord> builder)
    {
        _ = builder.ToTable("platform_pay_records");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_platform_pay_records");

        _ = builder.Property(c => c.PayAmount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Balance)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Balance)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.HasOne(e => e.PlatformCredit)
            .WithMany(e => e.BrandPayRecords)
            .HasForeignKey(e => e.PlatformCreditId)
            .HasConstraintName("fk_platform_credits_brand_quotas_id")
            .IsRequired();

        _ = builder.HasIndex(e => e.PlatformCreditId)
            .HasDatabaseName("ix_brand_credits_id");
    }
}
