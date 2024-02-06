#nullable enable
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendRecord
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public Guid AgentId { get; set; }

    public bool NegativeAgentDividendCarryForward { get; set; }

    public DistributeStatus Status { get; set; }

    public int AgentDividendId { get; set; }

    public decimal NegativeAgentDividendAmount { get; set; }

    public decimal AgentDividendAmount { get; set; }

    public decimal ActualAgentDividendAmount { get; set; }

    public string? Remark { get; set; }

    public string? SentByUsername { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? SentOn { get; set; }
}
