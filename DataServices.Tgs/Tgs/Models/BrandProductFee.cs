#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandProductFee
{
    public Guid BrandId { get; set; }
    public decimal CardGamePercentage { get; set; }
    public decimal LiveDealerPercentage { get; set; }
    public decimal LotteryPercentage { get; set; }
    public decimal SlotPercentage { get; set; }
    public decimal SportsPercentage { get; set; }
    public decimal VirtualSportsPercentage { get; set; }
    public string CreatedByUsername { get; set; }
    public string UpdatedByUsername { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
