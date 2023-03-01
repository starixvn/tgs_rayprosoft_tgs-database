#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionRebateDailyStatistics
{
    public decimal Bonus { get; set; }

    public Guid BrandId { get; set; }

    public decimal BucketAmount { get; set; }

    public string PlayerCode { get; set; } = default!;

    public Guid PromotionId { get; set; }

    public DateOnly ReportDate { get; set; }

    public string Settings { get; set; } = default!;

    public decimal TotalTurnover { get; set; }

    public DateTimeOffset ReportDateTime { get; set; }
}
