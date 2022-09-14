using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class FailedGameRecordOperationMap : IEntityTypeConfiguration<FailedGameRecordOperation>
{
    void IEntityTypeConfiguration<FailedGameRecordOperation>.Configure(EntityTypeBuilder<FailedGameRecordOperation> builder)
    {
        _ = builder.ToTable("failed_game_record_operations", Consts.BetSchema);

        _ = builder.HasKey(bc => bc.Id)
            .HasName("pk_failed_game_record_operations");

        _ = builder.Property(c => c.ExternalRoundId)
            .HasMaxLength(255)
            .IsRequired();

        _ = builder.Property(c => c.GameProviderId)
            .IsRequired();

        _ = builder.Property(c => c.PlayerCode)
            .HasMaxLength(16)
            .IsRequired();

        _ = builder.Property(c => c.GameId)
            .IsRequired();

        _ = builder.Property(c => c.ExternalId)
            .HasMaxLength(32)
            .IsRequired();

        _ = builder.Property(c => c.Detail)
            .IsRequired();

        _ = builder.Property(c => c.AutoStatus)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.ProcesStatus)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();
        _ = builder.Property(c => c.UpdatedOn)
            .IsRequired();

        _ = builder.HasIndex(c => new { c.GameProviderId, c.AutoStatus, c.ProcesStatus })
            .HasDatabaseName("ix_failed_game_record_operations_game_provider_id_auto_status_proces_status");

        _ = builder.HasIndex(c => new { c.ExternalRoundId, c.PlayerCode, c.GameProviderId, c.GameId })
            .IsUnique()
            .HasDatabaseName("ux_failed_game_record_operations_external_round_id_player_code_game_provider_id_game_id");
    }
}
