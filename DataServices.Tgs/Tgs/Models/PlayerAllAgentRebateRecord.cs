using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerAllAgentRebateRecord
{
    public Guid Id { get; set; }

    public Guid BrandId { get; set; }

    public string PlayerCode { get; set; }

    public AllAgentGameType AllAgentGameType { get; set; }

    public AllAgentRebateType AllAgentRebateType { get; set; }

    public int Rank { get; set; }

    public int ActiveNumber { get; set; }

    public decimal ConditionAmount { get; set; }

    public int ActualPlayerNumber { get; set; }

    public decimal ActualConditionAmount { get; set; }

    public decimal RebateAmount { get; set; }

    public decimal RebatePercentage { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset ReportDate { get; set; }
}
