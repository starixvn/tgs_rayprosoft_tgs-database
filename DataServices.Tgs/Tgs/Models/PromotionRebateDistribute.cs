using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionRebateDistribute
{
    public decimal Bonus { get; set; }

    public Guid BrandId { get; set; }

    public decimal BucketAmount { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTimeOffset DistributeFrom { get; set; }

    public DateTimeOffset DistributeTo { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; } = default!;

    public Guid PromotionId { get; set; }

    public string Settings { get; set; } = default!;

    public string Status { get; set; } = default!;
}
