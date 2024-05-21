#nullable enable

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentProductFee
{
    public Guid BrandId { get; set; }

    public Guid AgentId { get; set; }

    public decimal PreviousCardGamePercentage { get; set; }

    public decimal PreviousLiveDealerPercentage { get; set; }

    public decimal PreviousLotteryPercentage { get; set; }

    public decimal PreviousSlotPercentage { get; set; }

    public decimal PreviousSportsPercentage { get; set; }

    public decimal PreviousVirtualSportsPercentage { get; set; }

    public decimal CurrentCardGamePercentage { get; set; }

    public decimal CurrentLiveDealerPercentage { get; set; }

    public decimal CurrentLotteryPercentage { get; set; }

    public decimal CurrentSlotPercentage { get; set; }

    public decimal CurrentSportsPercentage { get; set; }

    public decimal CurrentVirtualSportsPercentage { get; set; }

    public decimal NextCardGamePercentage { get; set; }

    public decimal NextLiveDealerPercentage { get; set; }

    public decimal NextLotteryPercentage { get; set; }

    public decimal NextSlotPercentage { get; set; }

    public decimal NextSportsPercentage { get; set; }

    public decimal NextVirtualSportsPercentage { get; set; }

    public string CreatedByUsername { get; set; } = default!;

    public string UpdatedByUsername { get; set; } = default!;

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}