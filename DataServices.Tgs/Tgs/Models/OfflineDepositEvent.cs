using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class OfflineDepositEvent
{
    public decimal BonusAmount { get; set; }

    public Guid BrandId { get; set; }

    public decimal BucketAmount { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid DepositFormId { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; }

    public Guid PromotionId { get; set; }

    public string Settings { get; set; }
}
