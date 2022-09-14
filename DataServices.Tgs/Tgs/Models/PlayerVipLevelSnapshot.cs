using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class PlayerVipLevelSnapshot
{
    public Guid BrandId { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string Data { get; set; }

    public Guid Id { get; set; }

    public DateTimeOffset SnapshotOn { get; set; }
}
