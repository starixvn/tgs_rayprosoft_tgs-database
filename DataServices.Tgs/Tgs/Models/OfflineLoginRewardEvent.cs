using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class OfflineLoginRewardEvent
{
    public decimal Bonus { get; set; }

    public Guid BrandId { get; set; }

    public decimal Bucket { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; }

    public Guid PromotionId { get; set; }

    public DateTime LoggedOn { get; set; }
}
