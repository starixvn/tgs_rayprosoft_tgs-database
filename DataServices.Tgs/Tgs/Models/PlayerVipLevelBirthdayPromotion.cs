using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerVipLevelBirthdayPromotion
{
    public decimal Amount { get; set; }

    public DateTimeOffset Birthday { get; set; }

    public Guid BrandId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public int ExecuteYear { get; set; }

    public Guid Id { get; set; }

    public string PlayerCode { get; set; }

    public Guid PlayerVipLevelSnapshotId { get; set; }

    public Guid VipId { get; set; }
}
