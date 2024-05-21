
namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendProductFee
{
    public Guid BrandId { get; set; }
    public Guid AgentId { get; set; }
    public int AgentDividendId { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public decimal CardGamePercentage { get; set; }
    public decimal LiveDealerPercentage { get; set; }
    public decimal LotteryPercentage { get; set; }
    public decimal SlotPercentage { get; set; }
    public decimal SportsPercentage { get; set; }
    public decimal VirtualSportsPercentage { get; set; }
    public decimal CardGameWinLossAmount { get; set; }
    public decimal LiveDealerWinLossAmount { get; set; }
    public decimal LotteryWinLossAmount { get; set; }
    public decimal SlotWinLossAmount { get; set; }
    public decimal SportsWinLossAmount { get; set; }
    public decimal VirtualSportsWinLossAmount { get; set; }
    public DateTime CreatedOn { get; set; }
}
