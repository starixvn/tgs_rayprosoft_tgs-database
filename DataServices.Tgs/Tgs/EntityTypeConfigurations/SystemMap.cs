#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class SystemMap : IEntityTypeConfiguration<Models.System>
{
    public void Configure(EntityTypeBuilder<Models.System> builder)
    {
        _ = builder.ToTable("systems");

        _ = builder.HasKey(s => s.Name);
    }
}
