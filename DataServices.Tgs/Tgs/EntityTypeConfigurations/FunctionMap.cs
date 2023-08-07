#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class FunctionMap : IEntityTypeConfiguration<Function>
{
    public void Configure(EntityTypeBuilder<Function> builder)
    {
        _ = builder.ToTable("functions");

        _ = builder.HasKey(f => f.Id);
        _ = builder.HasAlternateKey(f => new { f.Name, f.System });

        _ = builder.Property(f => f.Name)
            .IsRequired();
        _ = builder.Property(f => f.System)
            .IsRequired();
        _ = builder.Property(f => f.Type)
            .IsRequired();
        _ = builder.Property(f => f.Status)
            .IsRequired();
        _ = builder.Property(f => f.Features)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(f => f.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(f => f.UpdatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        _ = builder.HasOne<Models.System>()
            .WithMany()
            .HasForeignKey(f => f.System)
            .HasConstraintName("fk_systems");
    }
}
