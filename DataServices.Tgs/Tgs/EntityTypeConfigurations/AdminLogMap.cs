using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public sealed class AdminLogMap : IEntityTypeConfiguration<AdminLog>
{
    void IEntityTypeConfiguration<AdminLog>.Configure(EntityTypeBuilder<AdminLog> builder)
    {
        _ = builder.ToTable("admin_logs", Consts.LogSchema);

        _ = builder.HasKey(p => p.Id);

        _ = builder.Property(c => c.Ip)
            .HasMaxLength(50)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.ServerName)
            .HasMaxLength(128)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Path)
            .HasMaxLength(256)
            .IsRequired(false)
            .IsUnicode();

        _ = builder.Property(c => c.Method)
            .HasMaxLength(256)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(256)
            .IsRequired();

        _ = builder.Property(c => c.RequestHeaders)
            .IsRequired();

        _ = builder.Property(c => c.RequestContent)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.ResponseHeaders)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.ResponseContent)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Exception)
            .IsUnicode();

        _ = builder.Property(c => c.StackTrace)
            .IsUnicode();

        _ = builder.Property(c => c.InnerException)
            .IsUnicode();

        _ = builder.Property(c => c.ResponseCode)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.ExecutionTimeMs);

        _ = builder.Property(c => c.RecordedOn)
            .IsRequired();
    }
}
