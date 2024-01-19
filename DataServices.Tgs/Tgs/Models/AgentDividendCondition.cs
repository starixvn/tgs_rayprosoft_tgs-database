using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendCondition
{
    public Guid AgentId { get; set; }

    public Guid ContractId { get; set; }

    public int Rank { get; set; }

    public int ActiveNumber { get; set; }

    public decimal DividendPercentage { get; set; }

    public decimal NetProfit { get; set; }

    public decimal WinLossAmount { get; set; }

    public virtual Agent Agent { get; set; }
}
