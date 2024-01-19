using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class AgentDividendRecord
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public Guid AgentId { get; set; }

    public int AgentDividendId { get; set; }

    public decimal AgentDividendAmount { get; set; }

    public string SentByUsername { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? SentOn { get; set; }
}
