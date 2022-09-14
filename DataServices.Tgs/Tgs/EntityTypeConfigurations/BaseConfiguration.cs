using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal abstract class BaseConfiguration
{
    protected static void ConfigureBaseProperties<TEntity, TId>(EntityTypeBuilder<TEntity> builder,
        string primaryKeyName = null)
        where TId : struct
        where TEntity : BaseEntity<TId>
    {
        _ = builder.HasKey(p => p.Id)
            .HasName(primaryKeyName);

        _ = builder.Property(c => c.Code)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.Name)
            .HasMaxLength(255)
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
