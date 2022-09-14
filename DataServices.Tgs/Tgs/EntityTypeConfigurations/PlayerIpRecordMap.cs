using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class PlayerIpRecordMap : IEntityTypeConfiguration<PlayerIpRecord>
{
    public void Configure(EntityTypeBuilder<PlayerIpRecord> builder)
    {
        _ = builder.ToTable("player_ip_records");

        _ = builder.HasKey(b => new { b.PlayerCode, b.IpType })
            .HasName("pk_player_ip_records");

        _ = builder.Property(b => b.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(b => b.IpType)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(b => b.Ip)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(b => b.Host)
            .HasMaxLength(250);

        _ = builder.Property(b => b.RecordOn)
            .IsRequired()
            .HasDefaultValueSql("Now()");

        _ = builder.HasOne<Player>()
            .WithMany()
            .HasForeignKey(b => b.PlayerCode)
            .HasConstraintName("fk_player_ip_records_players_player_code")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
