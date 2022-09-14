using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandAllAgentGameTypeCondition
{
    public int ActiveNumber { get; set; }

    public AllAgentGameType AllAgentGameType { get; set; }

    public AllAgentRebateType AllAgentRebateType { get; set; }

    public Guid BrandId { get; set; }

    public decimal NetProfit { get; set; }

    public int Rank { get; set; }

    public decimal RebatePercentage { get; set; }
}
