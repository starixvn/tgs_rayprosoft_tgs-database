using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class AccountEventSourceMap : IEntityTypeConfiguration<AccountEventSource>
{
    public void Configure(EntityTypeBuilder<AccountEventSource> builder)
    {
        _ = builder.ToTable("account_event_sources");

        _ = builder.HasKey(aes => aes.Id);
        _ = builder.Property(aes => aes.AccountId)
            .IsRequired();
        _ = builder.Property(aes => aes.ChangeSets)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(aes => aes.CreatedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}
