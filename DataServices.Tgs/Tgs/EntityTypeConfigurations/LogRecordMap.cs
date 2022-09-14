using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public sealed class LogRecordMap : IEntityTypeConfiguration<LogRecord>
{
    void IEntityTypeConfiguration<LogRecord>.Configure(EntityTypeBuilder<LogRecord> builder)
    {
        _ = builder.ToTable("log_records", Consts.LogSchema);

        _ = builder.HasKey(c => c.Id);

        _ = builder.Property(c => c.ServerName)
            .HasMaxLength(128)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Level)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Message)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Exception)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.RecordedOn)
            .IsRequired();
    }
}
