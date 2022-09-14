using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

public class BannerMap : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        _ = builder.ToTable("banners")
            .HasKey(b => b.Id);

        _ = builder.Property(b => b.BrandId)
            .IsRequired();

        _ = builder.Property(b => b.BeginTime)
            .IsRequired();
        _ = builder.Property(b => b.EndTime);

        _ = builder.Property(b => b.IsEnabled)
            .IsRequired()
            .HasDefaultValue(false);

        _ = builder.Property(b => b.Title)
            .IsRequired();
        _ = builder.Property(b => b.Status)
            .IsRequired()
            .HasDefaultValue(0);
        _ = builder.Property(b => b.Localization)
            .HasColumnType(ColumnTypes.Jsonb);
        _ = builder.Property(b => b.Remark);
        _ = builder.Property(b => b.DisplayOrder)
            .IsRequired()
            .HasDefaultValue(1);

        _ = builder.Property(b => b.CreatedByUserName)
            .IsRequired();
        _ = builder.Property(b => b.CreatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");
        _ = builder.Property(b => b.UpdatedByUserName)
            .IsRequired();
        _ = builder.Property(b => b.UpdatedOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(b => b.BrandId)
            .HasConstraintName("fk_banners_brands_brand_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
