using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerVipLevelSeasonPromotion
{
    public decimal Amount { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset FromOn { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; }

    public Guid PlayerVipLevelSnapshotId { get; set; }

    public DateTimeOffset SeasonOn { get; set; }

    public DateTimeOffset ToOn { get; set; }

    public Guid VipId { get; set; }
}
