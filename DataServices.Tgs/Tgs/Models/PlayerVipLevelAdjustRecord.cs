using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerVipLevelAdjustRecord
{
    public DateTimeOffset CreatedOn { get; set; }

    public Guid Id { get; set; }

    public Guid NewVipId { get; set; }

    public Guid OldVipId { get; set; }

    public Guid OperatorId { get; set; }

    public string PlayerCode { get; set; }

    public string Remark { get; set; }
}
