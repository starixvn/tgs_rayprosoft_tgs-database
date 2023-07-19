using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        _ = builder.ToTable("accounts");

        _ = builder.HasKey(a => a.Id)
            .HasName("pk_accounts");
        _ = builder.HasAlternateKey(a => new { a.UserName, a.System, a.BrandId })
            .HasName("ux_accounts_username_system_brand");

        _ = builder.Property(a => a.Algorithm)
            .IsRequired();
        _ = builder.Property(a => a.PasswordHash)
            .IsRequired();
        _ = builder.Property(a => a.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(a => a.UpdatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
        _ = builder.Property(a => a.SnapshotId)
            .IsRequired();
    }
}
