using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendMultipleLayer
{
    public virtual AgentDividend AgentDividend { get; set; }

    public int AgentDividendId { get; set; }

    public Guid AgentId { get; set; }

    public decimal Dividend { get; set; }

    public Guid DividendProviderAgentId { get; set; }

    public int Id { get; set; }

    public string Layer { get; set; }
}
