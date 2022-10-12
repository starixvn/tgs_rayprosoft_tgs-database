using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandPlayerBankInfoCheckFlagMap : IEntityTypeConfiguration<BrandPlayerBankInfoCheckFlag>
{
    public void Configure(EntityTypeBuilder<BrandPlayerBankInfoCheckFlag> builder)
    {
        _ = builder.ToTable("brand_player_bankinfo_check_flags");

        _ = builder.HasKey(flag => flag.BrandId);

        _ = builder.Property(flag => flag.IsEnabled)
            .IsRequired();
    }
}
