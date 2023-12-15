using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendMultipleLayer
{
    public virtual AgentDividend AgentDividend { get; set; }
    public int AgentDividendId { get; set; }
    public Guid AgentId { get; set; }
    public decimal AgentDividendPercentage { get; set; }
    public decimal ActualDividendPercentage { get; set; }
    public decimal? AgentCoveredBonus { get; set; }
    public decimal? AgentCoveredBonusAdjust { get; set; }
    public decimal Dividend { get; set; }
    public Guid DividendProviderAgentId { get; set; }
    public int DividendProviderId { get; set; }
    public int Id { get; set; }
    public string Layer { get; set; }
    public Guid ContractId { get; set; }
}