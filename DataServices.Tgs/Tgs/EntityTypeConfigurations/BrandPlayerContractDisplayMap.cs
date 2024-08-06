using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandPlayerContractDisplayMap : IEntityTypeConfiguration<BrandPlayerContractDisplay>
{
    public void Configure(EntityTypeBuilder<BrandPlayerContractDisplay> builder)
    {
        _ = builder.ToTable("brand_player_contract_display");

        _ = builder.HasKey(s => s.Id);

        _ = builder.Property(s => s.BrandId)
            .IsRequired();

        _ = builder.Property(s => s.Name)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(s => s.IsVisualized);

        _ = builder.Property(s => s.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();
        _ = builder.Property(s => s.CreatedBy)
            .HasMaxLength(256);

        _ = builder.Property(s => s.UpdatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();
        _ = builder.Property(s => s.UpdatedBy)
            .HasMaxLength(256)
            .IsRequired();
    }
}