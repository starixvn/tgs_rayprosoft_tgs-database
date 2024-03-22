#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class DepositPromotionStatistics
{
    public Guid PromotionId { get; set; }

    public string PlayerCode { get; set; } = default!;

    public DateTime ProcessedDate { get; set; }

    public int TotalDepositCount { get; set; }
}