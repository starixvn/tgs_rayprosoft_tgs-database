using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGroupGameProviderBetLimit
{
    public virtual BrandGroupBetLimit BrandGroupBetLimit { get; set; }

    public Guid BrandGroupBetLimitId { get; set; }

    public virtual GameProviderBetLimit GameProviderBetLimit { get; set; }

    public Guid GameProviderBetLimitId { get; set; }
}
