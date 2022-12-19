using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class WithdrawFormEventSourceMap : IEntityTypeConfiguration<WithdrawFormEventSource>
{
    public void Configure(EntityTypeBuilder<WithdrawFormEventSource> builder)
    {
        _ = builder.ToTable("withdraw_form_event_source");

        _ = builder.HasKey(wf => wf.Id);

        _ = builder.Property(wf => wf.FormId)
            .IsRequired();
        _ = builder.Property(wf => wf.ChangeSets)
            .HasColumnType("jsonb")
            .IsRequired();
        _ = builder.Property(wf => wf.Action)
            .IsRequired();
        _ = builder.Property(wf => wf.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();
        _ = builder.Property(wf => wf.ModifyUser);
    }
}
