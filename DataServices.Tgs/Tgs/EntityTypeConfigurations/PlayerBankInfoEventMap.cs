#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerBankInfoEventMap : IEntityTypeConfiguration<PlayerBankInfoEvent>
{
    public void Configure(EntityTypeBuilder<PlayerBankInfoEvent> builder)
    {
        _ = builder.ToTable("player_bank_info_event_source")
            .HasKey(p => p.Id);

        _ = builder.Property(p => p.BankInfoId)
            .IsRequired();
        _ = builder.Property(p => p.ChangeAction)
            .IsRequired();
        _ = builder.Property(p => p.ChangeSets)
            .IsRequired()
            .HasColumnType("jsonb");
        _ = builder.Property(p => p.Modifier);
        _ = builder.Property(p => p.ModifiedOn)
            .IsRequired()
            .HasColumnType("timestamptz");
    }
}