#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GroupMap : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        _ = builder.ToTable("groups");

        _ = builder.HasKey(g => g.Id);
        _ = builder.HasAlternateKey(g => new { g.Name, g.System });

        _ = builder.HasOne<Models.System>()
            .WithMany()
            .HasForeignKey(g => g.System)
            .HasConstraintName("fk_systems");
    }
}
