using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerAuthenticationFormMap : IEntityTypeConfiguration<PlayerAuthenticationForm>
{
    void IEntityTypeConfiguration<PlayerAuthenticationForm>.Configure(EntityTypeBuilder<PlayerAuthenticationForm> builder)
    {
        _ = builder.ToTable("player_authentication_forms");

        _ = builder.HasKey(paf => paf.Id)
            .HasName("pk_player_authentication_forms");

        _ = builder.Property(paf => paf.Id)
            .IsRequired();

        _ = builder.Property(paf => paf.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(paf => paf.BrandId)
            .IsRequired();

        _ = builder.Property(paf => paf.CreatedOn)
            .IsRequired();

        _ = builder.Property(paf => paf.Remark);

        _ = builder.Property(paf => paf.Data)
            .HasColumnType(ColumnTypes.Jsonb)
            .IsRequired();

        _ = builder.Property(paf => paf.Status)
            .IsRequired()
            .HasDefaultValue(0);
    }
}
