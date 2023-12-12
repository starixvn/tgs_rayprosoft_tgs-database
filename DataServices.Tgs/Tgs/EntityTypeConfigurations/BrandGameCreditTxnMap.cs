using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandGameCreditTxnMap : IEntityTypeConfiguration<BrandGameCreditTxn>
{
    void IEntityTypeConfiguration<BrandGameCreditTxn>.Configure(EntityTypeBuilder<BrandGameCreditTxn> builder)
    {
        _ = builder.ToTable("brand_game_credit_txns");

        _ = builder
            .HasKey(c => new { c.Id })
            .HasName("pk_brand_game_credit_txns");

        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.BrandId })
            .HasDatabaseName("ix_brand_game_credit_txns_created_on_brand_id");
        _ = builder
            .HasIndex(c => new { c.CreatedOn, c.BrandId, c.Type })
            .HasDatabaseName("ix_brand_game_credit_txns_created_on_brand_id_type");
        _ = builder
            .HasIndex(c => new { c.BrandId })
            .HasDatabaseName("ix_brand_game_credit_txns_brand_id");

        _ = builder.Property(c => c.Id)
            .IsRequired()
            .HasComment("識別碼");
        _ = builder.Property(c => c.BrandId)
            .IsRequired()
            .HasComment("平台識別碼");
        _ = builder.Property(c => c.Type)
            .IsRequired()
            .HasDefaultValue(1)
            .HasComment("交易類型");
        _ = builder.Property(b => b.Money)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("金錢");
        _ = builder.Property(b => b.Amount)
            .IsRequired()
            .HasPrecision(18, 6)
            .HasDefaultValue(0.0)
            .HasComment("額度");
        _ = builder.Property(b => b.Remark)
            .IsRequired()
            .HasDefaultValue("")
            .HasComment("備註");
        _ = builder.Property(b => b.Expansions)
            .IsRequired()
            .HasColumnType("jsonb")
            .HasDefaultValueSql("'{}'::jsonb")
            .HasComment("擴充");
        _ = builder.Property(b => b.CreatedUserId)
            .IsRequired()
            .HasDefaultValue(Guid.Empty)
            .HasComment("創建使用者識別碼");
        _ = builder.Property(b => b.CreatedUsername)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue(string.Empty)
            .HasComment("創建使用者名稱");
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("創建時間");
    }
}
