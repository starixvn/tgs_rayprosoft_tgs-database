#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandProductFee
{
    public Guid BrandId { get; set; }
    public decimal CardGameRebatePercentage { get; set; }
    public decimal LiveDealerRebatePercentage { get; set; }
    public decimal LotteryRebatePercentage { get; set; }
    public decimal SlotRebatePercentage { get; set; }
    public decimal SportsRebatePercentage { get; set; }
    public decimal VirtualSportsRebatePercentage { get; set; }
    public required string CreatedByUsername { get; set; }
    public required string UpdatedByUsername { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
