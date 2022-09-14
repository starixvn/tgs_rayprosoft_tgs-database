using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class TransactionPromotion
{
    public virtual Promotion Promotion { get; set; }

    public Guid PromotionBonusId { get; set; }

    public Guid PromotionId { get; set; }

    public string PromotionType { get; set; }

    public Guid TransactionId { get; set; }
}
