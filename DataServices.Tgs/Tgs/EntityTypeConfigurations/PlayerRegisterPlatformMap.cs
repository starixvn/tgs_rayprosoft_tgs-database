using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerRegisterPlatformMap : IEntityTypeConfiguration<PlayerRegisterPlatform>
{
    void IEntityTypeConfiguration<PlayerRegisterPlatform>.Configure(EntityTypeBuilder<PlayerRegisterPlatform> builder)
    {
        _ = builder.ToTable("player_register_platforms");

        _ = builder.HasKey(bc => bc.PlayerCode)
            .HasName("pk_player_code");

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.Type)
            .HasColumnType(ColumnTypes.SmallInt)
            .HasDefaultValue(RegisterPlatformType.Player)
            .IsRequired();

        _ = builder.Property(c => c.CreatedByUsername)
            .IsRequired();

        _ = builder.Property(b => b.CreatedOn)
            .IsRequired();
    }
}
