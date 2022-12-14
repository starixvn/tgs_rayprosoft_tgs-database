using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class ReliefPromotionJoinPlayer
{
    public DateTime CreatedOn { get; set; }

    public string PlayerCode { get; set; }

    public Guid PromotionId { get; set; }
}
