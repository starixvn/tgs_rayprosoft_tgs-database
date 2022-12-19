using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class WithdrawFormEventSourceMap : IEntityTypeConfiguration<WithdrawFormEventSource>
{
    public void Configure(EntityTypeBuilder<WithdrawFormEventSource> builder)
    {
        _ = builder.ToTable("withdraw_form_event_source");

        _ = builder.HasKey(df => df.Id);

        _ = builder.Property(df => df.FormId)
            .IsRequired();
        _ = builder.Property(df => df.ChangeSets)
            .HasColumnType("jsonb")
            .IsRequired();
        _ = builder.Property(df => df.Action)
            .IsRequired();
        _ = builder.Property(df => df.CreatedOn)
            .HasColumnType("timestamptz")
            .IsRequired();
        _ = builder.Property(df => df.ModifyUser);
    }
}
