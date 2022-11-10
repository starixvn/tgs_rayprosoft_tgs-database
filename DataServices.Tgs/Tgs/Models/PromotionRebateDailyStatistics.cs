#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionRebateDailyStatistics
{
    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; } = default!;

    public Guid PromotionId { get; set; }

    public decimal RebateAmount { get; set; }

    public DateOnly ReportDate { get; set; }
}
