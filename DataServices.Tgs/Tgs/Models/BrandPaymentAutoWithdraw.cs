#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandPaymentAutoWithdraw
{
    public decimal AmountUpperLimit { get; set; }

    public Guid BrandId { get; set; }

    public string BrandPaymentCandidates { get; set; } = default!;

    public bool EnableAutoWithdraw { get; set; }

    public Guid SnapshotEventId { get; set; }
}
