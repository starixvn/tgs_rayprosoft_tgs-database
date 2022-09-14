using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TGS.Core.DataServices.Base;
using TGS.Core.DataServices.Tgs.Migrations;
using TGS.Core.DataServices.Tgs.Models;

namespace TGS.Core.DataServices.Tgs.EntityTypeConfigurations;

internal class GameActionMap : IEntityTypeConfiguration<GameAction>
{
    void IEntityTypeConfiguration<GameAction>.Configure(EntityTypeBuilder<GameAction> builder)
    {
        _ = builder.ToTable("game_actions", Consts.BetSchema);

        _ = builder.HasKey(c => c.Id)
            .HasName("pk_game_actions");

        _ = builder.Property(c => c.PlayerCode)
            .IsRequired();

        _ = builder.Property(c => c.IsClosingRound)
            .IsRequired();

        _ = builder.Property(c => c.ExternalTransactionId)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(c => c.Type)
            .HasColumnType(ColumnTypes.SmallInt)
            .IsRequired();

        _ = builder.Property(c => c.RoundId)
            .IsRequired();

        _ = builder.Property(c => c.RecordedOn)
            .IsRequired();

        _ = builder.Property(c => c.SentOn)
            .IsRequired(false);

        // shadow property, no actual property in GameAction model
        _ = builder.Property<DateTimeOffset>("StoredOn")
            .HasDefaultValueSql("now()")
            .IsRequired();

        _ = builder.Property(c => c.Turnover)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.WinLoss)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.UnsettledBets)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Amount)
            .HasPrecision(18, 6)
            .IsRequired();

        _ = builder.Property(c => c.Balance)
            .HasPrecision(18, 6);

        _ = builder.Property(c => c.PlayerIp)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(c => c.ExternalGameActionGroupId)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(c => c.ExternalBetId)
            .HasMaxLength(128)
            .IsRequired();

        _ = builder.Property(c => c.BetType)
            .HasMaxLength(128);

        _ = builder.Property(c => c.ExtraData);

        _ = builder.Property(c => c.JackpotContribution)
            .HasColumnType(ColumnTypes.Jsonb);

        _ = builder.HasIndex(e => e.PlayerCode)
            .HasDatabaseName("ix_game_actions_player_code");

        _ = builder.HasOne(c => c.Round)
            .WithMany(c => c.GameActions)
            .HasForeignKey(c => c.RoundId)
            .HasConstraintName("fk_game_actions_rounds_round_id");

        _ = builder.HasIndex(c => c.RoundId)
            .HasDatabaseName("ix_game_actions_round_id");

        _ = builder.HasOne(c => c.ReferencedGameAction)
            .WithMany(c => c.FollowUpGameActions)
            .HasForeignKey(c => c.ReferencedGameActionId)
            .HasConstraintName("fk_game_actions_referenced_game_action_id");

        _ = builder.HasIndex(c => c.ReferencedGameActionId)
            .HasDatabaseName("ix_game_actions_referenced_game_action_id");

        _ = builder.HasOne(c => c.GameActionBatch)
            .WithMany(c => c.GameActions)
            .HasForeignKey(c => c.GameActionBatchId)
            .HasConstraintName("fk_game_actions_game_action_batches_game_action_batch_id");

        _ = builder.HasIndex(c => c.GameActionBatchId)
            .HasDatabaseName("ix_game_actions_game_action_batch_id");
    }
}
