using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendCondition
{
    public int ActiveNumber { get; set; }

    public virtual Agent Agent { get; set; }

    public Guid AgentId { get; set; }

    public decimal DividendPercentage { get; set; }

    public decimal NetProfit { get; set; }

    public int Rank { get; set; }
}
