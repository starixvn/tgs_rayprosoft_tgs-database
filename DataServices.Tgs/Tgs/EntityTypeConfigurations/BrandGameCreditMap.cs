using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGameCreditMap : IEntityTypeConfiguration<BrandGameCredit>
{
    void IEntityTypeConfiguration<BrandGameCredit>.Configure(EntityTypeBuilder<BrandGameCredit> builder)
    {
        _ = builder.ToTable("brand_game_credits");

        _ = builder
            .HasKey(c => new { c.Month, c.ResellerId, c.LicenseeId, c.BrandId })
            .HasName("pk_brand_game_credits");

        _ = builder
            .HasIndex(c => new { c.Month, c.ResellerId })
            .HasDatabaseName("ix_brand_game_credits_reseller_id");
        _ = builder
            .HasIndex(c => new { c.Month, c.LicenseeId })
            .HasDatabaseName("ix_brand_game_credits_licensee_id");
        _ = builder
            .HasIndex(c => new { c.Month, c.BrandId })
            .HasDatabaseName("ix_brand_game_credits_brand_id");
        _ = builder
            .HasIndex(c => new { c.Month })
            .HasDatabaseName("ix_brand_game_credits_month");

        _ = builder.Property(c => c.ResellerId)
            .IsRequired()
            .HasComment("公司識別碼");
        _ = builder.Property(c => c.LicenseeId)
            .IsRequired()
            .HasComment("分公司識別碼");
        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");
        _ = builder.Property(c => c.Month)
            .IsRequired()
            .HasDefaultValueSql("'1990-01-01':: date")
            .HasComment("月份");
        _ = builder.Property(b => b.InitialAmount)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("初始額度");
        _ = builder.Property(b => b.CreditAmount)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("上分額度");
        _ = builder.Property(b => b.DebitAmount)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("下分額度");
        _ = builder.Property(b => b.ProfitAmount)
            .HasPrecision(18, 6)
            .IsRequired()
            .HasDefaultValue(0.0)
            .HasComment("利潤額度");
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
