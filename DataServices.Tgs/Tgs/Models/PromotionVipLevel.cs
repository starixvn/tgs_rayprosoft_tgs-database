using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionVipLevel
{
    public int Level { get; set; }

    public virtual Promotion Promotion { get; set; }

    public Guid PromotionId { get; set; }

    public virtual VipLevel VipLevel { get; set; }

    public Guid VipLevelId { get; set; }
}
