using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public sealed class RoleMap : IEntityTypeConfiguration<Role>
{
    void IEntityTypeConfiguration<Role>.Configure(EntityTypeBuilder<Role> builder)
    {
        _ = builder.ToTable("roles");

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_roles");

        _ = builder.Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(c => c.DisplayName)
            .HasMaxLength(50)
            .IsRequired(false);

        _ = builder.Property(c => c.Description)
            .HasMaxLength(128)
            .IsRequired(false);

        _ = builder.Property(c => c.MenuSetting)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();

        _ = builder.Property(c => c.RoleType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();
    }
}
