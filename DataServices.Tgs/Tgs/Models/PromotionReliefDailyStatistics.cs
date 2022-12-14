using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionReliefDailyStatistics
{
    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; } = default!;

    public Guid PromotionId { get; set; }

    public DateOnly ReportDate { get; set; }

    public string Settings { get; set; } = default!;

    public decimal TotalWinLoss { get; set; }
}
