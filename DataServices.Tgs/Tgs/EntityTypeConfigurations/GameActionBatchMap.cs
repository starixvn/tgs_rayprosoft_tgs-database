using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameActionBatchMap : IEntityTypeConfiguration<GameActionBatch>
{
    void IEntityTypeConfiguration<GameActionBatch>.Configure(EntityTypeBuilder<GameActionBatch> builder)
    {
        _ = builder.ToTable("game_action_batches", Consts.BetSchema);

        _ = builder.HasKey(bc => bc.Id)
            .HasName("pk_game_action_batches");

        _ = builder.Property(c => c.Error)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.TransactionsCount)
            .IsRequired();

        _ = builder.Property(c => c.CreatedOn)
            .IsRequired();

        _ = builder.Property(c => c.ExternalId)
            .HasMaxLength(64)
            .IsRequired();

        _ = builder.Property(c => c.ErrorMessage)
            .HasMaxLength(1024);

        _ = builder.Property(c => c.GameProviderId)
            .IsRequired();

        _ = builder.Property(c => c.ErrorsJson)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.HasOne(c => c.GameProvider)
            .WithMany()
            .HasForeignKey(c => c.GameProviderId)
            .HasConstraintName(
                "fk_game_action_batches_game_provider_configurations_game_provider_id");

        _ = builder.HasIndex(c => c.GameProviderId)
            .HasDatabaseName("ix_game_action_batches_game_provider_id");
    }
}
