using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class Calculate
{
    public Guid Id { get; set; }

    public decimal Balance { get; set; }

    public Guid SnapshotId { get; set; }

    public bool Deleted { get; set; }
}
