using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class RebatePromotionJoinPlayer
{
    public DateTime CreatedOn { get; set; }

    public string PlayerCode { get; set; }

    public Guid PromotionId { get; set; }
}
