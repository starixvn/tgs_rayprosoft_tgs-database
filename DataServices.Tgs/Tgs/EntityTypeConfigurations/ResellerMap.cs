using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class ResellerMap : BaseConfiguration, IEntityTypeConfiguration<Reseller>
{
    void IEntityTypeConfiguration<Reseller>.Configure(EntityTypeBuilder<Reseller> builder)
    {
        _ = builder.ToTable("resellers");

        ConfigureBaseProperties<Reseller, Guid>(builder, "pk_resellers");

        _ = builder.Property(c => c.Status)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.Description)
            .HasMaxLength(256);

        _ = builder.Property(c => c.OperationalEmail)
            .HasMaxLength(128);

        _ = builder.Property(e => e.BusinessType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();
    }
}
