#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GroupUserMap : IEntityTypeConfiguration<GroupUser>
{
    public void Configure(EntityTypeBuilder<GroupUser> builder)
    {
        _ = builder.ToTable("group_users");

        _ = builder.HasKey(gu => new { gu.GroupId, gu.UserId, gu.System });

        _ = builder.HasOne<Models.System>()
            .WithMany()
            .HasForeignKey(gu => gu.System)
            .HasConstraintName("fk_systems");
        _ = builder.HasOne<Group>()
            .WithMany()
            .HasForeignKey(gu => gu.GroupId)
            .HasConstraintName("fk_groups");
    }
}
