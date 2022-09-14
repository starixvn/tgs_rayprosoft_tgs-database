using System;
using System.Collections.Generic;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandGroupBetLimit
{
    public virtual BetLimit BetLimit { get; set; }

    public int BetLimitId { get; set; }

    public virtual BrandGroup BrandGroup { get; set; }

    public Guid BrandGroupId { get; set; }

    public virtual ICollection<BrandGroupGameProviderBetLimit> GameProviderBetLimits { get; set; }

    public Guid Id { get; set; }
}
