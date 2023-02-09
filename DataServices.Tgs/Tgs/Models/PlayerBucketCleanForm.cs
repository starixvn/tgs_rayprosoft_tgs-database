#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerBucketCleanForm
{
    public Guid BrandId { get; set; }

    public Guid BucketAnchorId { get; set; }

    public decimal? CleaningBalance { get; set; }

    public decimal? CleaningBucketAmount { get; set; }

    public decimal ClearWageringRequirementBalance { get; set; }

    public DateTime CreatedOn { get; set; }

    public decimal CurrentBalance { get; set; }

    public decimal CurrentBucketAmount { get; set; }

    public Guid DepositFormId { get; set; }

    public string? GameBalanceReturn { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; } = default!;

    public string Status { get; set; } = default!;

    public Guid WalletId { get; set; }
}
