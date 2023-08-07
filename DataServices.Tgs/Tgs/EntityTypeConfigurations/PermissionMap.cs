#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PermissionMap : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        _ = builder.ToTable("permissions");

        _ = builder.HasKey(p => p.Id);

        _ = builder.Property(p => p.FunctionId)
            .IsRequired();
        _ = builder.Property(p => p.IdentityType)
            .IsRequired();
        _ = builder.Property(p => p.Identity)
            .IsRequired();
        _ = builder.Property(p => p.System)
            .IsRequired();
        _ = builder.Property(p => p.Order)
            .IsRequired();
        _ = builder.Property(p => p.Action)
            .IsRequired();
        _ = builder.Property(p => p.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");

        _ = builder.HasOne<Models.System>()
            .WithMany()
            .HasForeignKey(p => p.System)
            .HasConstraintName("fk_systems");
        _ = builder.HasOne<Function>()
            .WithMany()
            .HasForeignKey("fk_functions");
    }
}
