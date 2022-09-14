using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public sealed class UserMap : IEntityTypeConfiguration<User>
{
    void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
    {
        _ = builder.ToTable("users");

        _ = builder.HasKey(p => p.Id)
            .HasName("pk_users");

        _ = builder.Property(c => c.Username)
            .HasMaxLength(50)
            .IsRequired();

        _ = builder.Property(c => c.RoleId)
            .IsRequired();

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Name)
            .HasMaxLength(30)
            .IsRequired();

        _ = builder.Property(c => c.TimeZone)
            .HasMaxLength(256)
            .IsRequired(false);

        _ = builder.Property(c => c.LastLoginIp)
            .HasMaxLength(128)
            .IsRequired(false);

        _ = builder.Property(c => c.Password)
            .IsRequired();

        _ = builder.Property(c => c.Salt)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedByUsername)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.LastLoginTime);

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder.HasOne(p => p.Role)
            .WithMany(p => p.Users)
            .HasForeignKey(p => p.RoleId)
            .HasConstraintName("fk_users_roles_role_id");

        _ = builder.HasIndex(e => e.RoleId)
            .HasDatabaseName("ix_users_role_id");

        _ = builder.HasOne(p => p.Department)
            .WithMany(p => p.Users)
            .HasForeignKey(p => p.DepartmentId)
            .HasConstraintName("fk_users_departments_department_id");

        _ = builder.HasIndex(e => e.DepartmentId)
            .HasDatabaseName("ix_users_department_id");
    }
}
