using System;
using TGS.Core.Models.Enums;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionMilestone
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public Guid PromotionId { get; set; }
    public int MilestoneLevel { get; set; }
    public decimal Bonus { get; set; }
    public decimal BucketAmount { get; set; }
    public decimal DepositAmount { get; set; }
    public decimal ValidBetAmount { get; set; }
    public DateTime CreatedOn { get; set; }
    public string PlayerCode { get; set; } = default!;
    public Guid? PromotionDistributeId { get; set; }
    public virtual PromotionDistribute PromotionDistribute { get; set; }
}
