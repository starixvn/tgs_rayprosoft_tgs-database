using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class ResellerBetLimit
{
    public virtual BetLimit BetLimit { get; set; }

    public int BetLimitId { get; set; }

    public virtual Reseller Reseller { get; set; }

    public Guid ResellerId { get; set; }
}
