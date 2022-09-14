using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class BrandPaymentVipLevel
{
    public virtual BrandPayment BrandPayment { get; set; }

    public Guid BrandPaymentId { get; set; }

    public virtual VipLevel VipLevel { get; set; }

    public Guid VipLevelId { get; set; }
}
