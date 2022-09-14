using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class ResellerGameProvider
{
    public virtual GameProvider GameProvider { get; set; }

    public Guid GameProviderId { get; set; }

    public virtual Reseller Reseller { get; set; }

    public Guid ResellerId { get; set; }
}
