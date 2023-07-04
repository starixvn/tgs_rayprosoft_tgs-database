#nullable enable

using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionPromoteDepositChannel
{
    public decimal Bonus { get; set; }

    public decimal BucketAmount { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid DistributePlanId { get; set; }

    public Guid FormId { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; } = default!;

    public Guid PromotionId { get; set; }

    public int VipLevel { get; set; }
}
