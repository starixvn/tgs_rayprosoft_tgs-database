using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBucketMigrationMap : IEntityTypeConfiguration<PlayerBucketMigration>
{
    public void Configure(EntityTypeBuilder<PlayerBucketMigration> builder)
    {
        builder.ToTable("player_bucket_migrations");

        builder.HasKey(pbm => pbm.PlayerCode);
    }
}
