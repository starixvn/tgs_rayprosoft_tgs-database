using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class BrandSmsMap : IEntityTypeConfiguration<BrandSms>
{
    void IEntityTypeConfiguration<BrandSms>.Configure(EntityTypeBuilder<BrandSms> builder)
    {
        _ = builder.ToTable("brand_sms");

        _ = builder.HasKey(s => new { s.BrandId, s.SmsSettingId });
    }
}