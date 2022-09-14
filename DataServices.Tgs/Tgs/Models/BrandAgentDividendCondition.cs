using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandAgentDividendCondition
{
    public int ActiveNumber { get; set; }

    public virtual Brand Brand { get; set; }

    public Guid BrandId { get; set; }

    public decimal DividendPercentage { get; set; }

    public decimal NetProfit { get; set; }

    public int Rank { get; set; }
}
