#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBucketCleanForm2Map : IEntityTypeConfiguration<PlayerBucketCleanForm2>
{
    public void Configure(EntityTypeBuilder<PlayerBucketCleanForm2> builder)
    {
        _ = builder
            .ToTable("player_bucket_clean_forms2");

        _ = builder.HasKey(x => x.Id)
            .HasName("pk_player_bucket_clean_forms2");

        _ = builder.Property(form => form.PlayerCode)
            .IsRequired();
        _ = builder.Property(form => form.WalletId)
            .IsRequired();
        _ = builder.Property(form => form.BrandId)
            .IsRequired();
        _ = builder.Property(form => form.CurrentBalance)
            .IsRequired();
        _ = builder.Property(form => form.CurrentBucketAmounts)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(form => form.DepositFormId)
            .IsRequired();
        _ = builder.Property(form => form.ClearWageringRequirementBalance)
            .IsRequired();
        _ = builder.Property(form => form.CleaningBucketAmounts)
            .HasColumnType("jsonb");
        _ = builder.Property(form => form.CleaningBalance);
        _ = builder.Property(form => form.GameBalanceReturn)
            .HasColumnType("jsonb");
        _ = builder.Property(form => form.Status)
            .IsRequired();
        _ = builder.Property(form => form.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(form => form.SnapshotId)
            .IsRequired();

        _ = builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(form => form.BrandId)
            .HasConstraintName("fk_player_bucket_clean_forms_brands2")
            .OnDelete(DeleteBehavior.Cascade);
        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(form => form.PlayerCode)
            .HasConstraintName("fk_player_bucket_clean_forms_players2")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
