using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public sealed class ApiLogMap : IEntityTypeConfiguration<ApiLog>
{
    void IEntityTypeConfiguration<ApiLog>.Configure(EntityTypeBuilder<ApiLog> builder)
    {
        _ = builder.ToTable("api_logs", Consts.LogSchema);

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
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Method)
            .HasMaxLength(256)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.Prefix)
            .HasMaxLength(256)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.RequestHeaders)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.RequestContent)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.ResponseHeaders)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.ResponseContent)
            .IsRequired()
            .IsUnicode();

        _ = builder.Property(c => c.ResponseCode)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.ExecutionTimeMs);

        _ = builder.Property(c => c.RecordedOn)
            .IsRequired();
    }
}
