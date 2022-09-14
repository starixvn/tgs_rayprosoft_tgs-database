using System;

namespace TGS.Core.DataServices.Tgs.Models;

public class LicenseeGameProvider
{
    public virtual GameProvider GameProvider { get; set; }

    public Guid GameProviderId { get; set; }

    public virtual Licensee Licensee { get; set; }

    public Guid LicenseeId { get; set; }
}
