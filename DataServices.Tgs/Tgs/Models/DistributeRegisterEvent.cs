using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class DistributeRegisterEvent
{
    public decimal Bonus { get; set; }

    public Guid BrandId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; }

    public Guid PromotionId { get; set; }
}
