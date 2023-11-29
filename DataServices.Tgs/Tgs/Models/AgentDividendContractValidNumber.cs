#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendContractValidNumber
{
    public Guid Id { get; set; }
    public decimal ValidBetAmount { get; set; }
    public decimal DepositAmount { get; set; }
    public int BetDays { get; set; }
    public Guid AgentDividendContractId { get; set; }
    public virtual AgentDividendContract AgentDividendContract { get; set; } = null!;
}
