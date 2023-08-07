#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class FunctionEventSourceMap : IEntityTypeConfiguration<FunctionEventSource>
{
    public void Configure(EntityTypeBuilder<FunctionEventSource> builder)
    {
        _ = builder.ToTable("function_event_sources");

        _ = builder.HasKey(fes => fes.Id);

        _ = builder.Property(fes => fes.FunctionId)
            .IsRequired();
        _ = builder.Property(fes => fes.System)
            .IsRequired();
        _ = builder.Property(fes => fes.ChangeSets)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(fes => fes.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        _ = builder.HasOne<Function>()
            .WithMany()
            .HasForeignKey(fes => fes.FunctionId)
            .HasConstraintName("fk_functions");
        _ = builder.HasOne<Models.System>()
            .WithMany()
            .HasForeignKey(fes => fes.System)
            .HasConstraintName("fk_systems");
    }
}
