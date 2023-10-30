using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class BrandAllAgentSettingMap : IEntityTypeConfiguration<BrandAllAgentSetting>
{
    void IEntityTypeConfiguration<BrandAllAgentSetting>.Configure(EntityTypeBuilder<BrandAllAgentSetting> builder)
    {
        _ = builder.ToTable("brand_all_agent_settings");

        _ = builder.HasKey(bc => bc.BrandId)
            .HasName("pk_brand_all_agent_settings");

        _ = builder.Property(c => c.SettlementIntervalType)
            .HasColumnType(ColumnTypes.SmallInt);
    }
}
