using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class LicenseeMap : BaseConfiguration, IEntityTypeConfiguration<Licensee>
{
    void IEntityTypeConfiguration<Licensee>.Configure(EntityTypeBuilder<Licensee> builder)
    {
        _ = builder.ToTable("licensees");

        ConfigureBaseProperties<Licensee, Guid>(builder, "pk_licensees");

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(256);

        _ = builder.Property(c => c.OperationalEmail)
            .HasMaxLength(128);

        _ = builder.Property(c => c.ReferenceId)
            .HasMaxLength(256);

        _ = builder.HasOne(p => p.Reseller)
            .WithMany(p => p.Licensees)
            .HasForeignKey(p => p.ResellerId)
            .HasConstraintName("fk_licensees_resellers_reseller_id");

        _ = builder.HasIndex(e => e.ResellerId)
            .HasDatabaseName("ix_licensees_reseller_id");
    }
}
