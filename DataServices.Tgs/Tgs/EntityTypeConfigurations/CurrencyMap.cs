using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class CurrencyMap : IEntityTypeConfiguration<Currency>
{
    void IEntityTypeConfiguration<Currency>.Configure(EntityTypeBuilder<Currency> builder)
    {
        _ = builder.ToTable("currencies");

        _ = builder.HasKey(p => p.Code)
            .HasName("pk_currencies");

        _ = builder.Property(c => c.Code)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.Name)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.NativeName)
            .HasMaxLength(64);

        _ = builder.Property(c => c.Symbol)
            .HasMaxLength(6);

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
