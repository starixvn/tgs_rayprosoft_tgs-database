using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PromotionPlayer
{
    public decimal BonusAmount { get; set; }

    public decimal BucketAmountByManual { get; set; }

    public int Id { get; set; }

    public virtual Player Player { get; set; }

    public string PlayerCode { get; set; }

    public virtual PromotionBonus PromotionBonus { get; set; }

    public Guid PromotionBonusId { get; set; }

    public string SentByUsername { get; set; }

    public DateTimeOffset? SentOn { get; set; }
}
