using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AdjustTransferRecordMap : IEntityTypeConfiguration<AdjustTransferRecord>
{
    void IEntityTypeConfiguration<AdjustTransferRecord>.Configure(EntityTypeBuilder<AdjustTransferRecord> builder)
    {
        _ = builder.ToTable("adjust_transfer_records");

        _ = builder.HasKey(bc => bc.Id)
            .HasName("pk_adjust_transfer_record_id");

        _ = builder.Property(c => c.TransactionFromId)
            .IsRequired();

        _ = builder.Property(c => c.TransactionToId)
            .IsRequired();

        _ = builder.Property(c => c.TransferType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.TransferFromUsername)
            .IsRequired();

        _ = builder.Property(c => c.TransferToUsername)
            .IsRequired();

        _ = builder.Property(c => c.Amount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(l => l.CreatedOn)
            .IsRequired();

        _ = builder.HasIndex(c => new
        {
            c.CreatedOn,
            c.TransferType,
            c.TransferFromUsername,
            c.TransferToUsername
        })
            .HasDatabaseName("ix_adjust_transfer_record_multiple_keys");
    }
}
