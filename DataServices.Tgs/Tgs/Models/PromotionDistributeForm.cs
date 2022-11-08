using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionDistributeForm
{
    public decimal BonusAmount { get; set; }

    public Guid BrandId { get; set; }

    public decimal Bucket { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public Guid Id { get; set; }

    public Guid? PlanId { get; set; }

    public string PlayerCode { get; set; } = default!;

    public Guid PromotionId { get; set; }
}
