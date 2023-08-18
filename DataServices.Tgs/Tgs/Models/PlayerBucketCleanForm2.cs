#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBucketCleanForm2
{
    public Guid BrandId { get; set; }

    public decimal? CleaningBalance { get; set; }

    public string? CleaningBucketAmounts { get; set; }

    public decimal ClearWageringRequirementBalance { get; set; }

    public DateTime CreatedOn { get; set; }

    public decimal CurrentBalance { get; set; }

    public string CurrentBucketAmounts { get; set; } = default!;

    public Guid DepositFormId { get; set; }

    public string? GameBalanceReturn { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; } = default!;

    public Guid SnapshotId { get; set; }

    public string Status { get; set; } = default!;

    public Guid WalletId { get; set; }
}
