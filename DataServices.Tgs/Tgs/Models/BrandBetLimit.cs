using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandBetLimit
{
    public virtual BetLimit BetLimit { get; set; }

    public int BetLimitId { get; set; }

    public virtual Brand Brand { get; set; }

    public Guid BrandId { get; set; }

    public bool IsDefault { get; set; }
}
